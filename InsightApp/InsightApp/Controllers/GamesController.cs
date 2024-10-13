using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InsightApp.Entities;
using InsightApp.Models;
using System.Reflection.Metadata;

namespace InsightApp.Controllers
{
    public class GamesController : Controller
    {
        private readonly InsightUpdateCvgs2Context _SVGSDbContext;

        public GamesController(InsightUpdateCvgs2Context context)
        {
            _SVGSDbContext = context;
        }

        // GET: Games
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> List(GamesListModel gamesListModel)
        {
            if (gamesListModel.SearchText == null)
            {
                //will return only the events that (isDeleted=false)
                var allGames = await _SVGSDbContext.Games
                                        .Include(g => g.GameDetailsCategories)          // Include GameDetailsCategories
                                            .ThenInclude(gdc => gdc.Category)           // Include the related Category entity
                                        .Where(g => g.IsDeleted == false)               // Only include non-deleted games
                                        .Select(g => new GamesCategoriesViewModel
                                        {
                                            GameId = g.GameId,
                                            GameName = g.GameName,
                                            GamePrice = g.Price,
                                            Categories = g.GameDetailsCategories
                                                .Where(gdc => gdc.Category != null)     // Ensure Category is not null
                                                .Select(gdc => gdc.Category.CategoryName)  // Select the CategoryName from the Category entity
                                                .ToList()
                                        })
                                        .OrderBy(g => g.GameName)
                                        .ToListAsync();

                gamesListModel.GamesList = allGames;

            }
            else
            {
				//will return only the games that (isDeleted=false) && Contains SearchText
				// Filter games based on the search text (search by game name or category)
				var allGames = await _SVGSDbContext.Games
                    .Include(g => g.GameDetailsCategories)
                        .ThenInclude(gdc => gdc.Category)
                    .Where(g => g.IsDeleted == false &&
                                (g.GameName.Contains(gamesListModel.SearchText) || // Search by game name
                                 g.GameDetailsCategories.Any(gdc => gdc.Category.CategoryName.Contains(gamesListModel.SearchText)))) // Search by category name
                    .Select(g => new GamesCategoriesViewModel
                    {
                        GameId = g.GameId,
                        GameName = g.GameName,
                        GamePrice = g.Price,
                        Categories = g.GameDetailsCategories
                            .Where(gdc => gdc.Category != null)
                            .Select(gdc => gdc.Category.CategoryName)
                            .ToList()
                    })
                    .OrderBy(g => g.GameName)
                    .ToListAsync();

                gamesListModel.GamesList = allGames;

            }

            return View("List", gamesListModel);
        }




        // GET: Games/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                //return NotFound();----------------------------temporary fix
                return View();
            }
            ViewBag.Title = "Game Details";
            return await EditGame(id);
        }



        // GET: Games/New
        [HttpGet("Games/New")]
        public async Task<IActionResult> AddNewGame()
        {
            // Call EditGame with null to indicate a new game
            return await EditGame(null);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> ViewEditGame(int id)
        {
            // Call EditGame with null to indicate a new game
            return await EditGame(id);
        }

        [HttpGet]
        // Common method to handle both adding new game and editing
        private async Task<IActionResult> EditGame(int? id)
        {
            // Create a new view model to pass to the view
            var viewModel = new EditGameViewModel();

            string returnView = "";

            if (id == null)
            {
                // This means we're adding a new game
                viewModel.Game = new Game { IsDeleted = false }; // Default value for IsDeleted
                viewModel.SelectedCategoryIds = new List<int?>();
                viewModel.SelectedLanguageIds = new List<int?>();
                viewModel.SelectedPlatformIds = new List<int?>();
                ViewBag.Title = "Add New Game";
                returnView = "Edit";
            }
            else
            {
                // Edit existing game: Retrieve the game from the database
                viewModel.Game = await _SVGSDbContext.Games
                    .Include(g => g.GameDetailsCategories)
                    .Include(g => g.GameDetailsLanguages)
                    .Include(g => g.GameDetailsPlatforms)
                    .FirstOrDefaultAsync(m => m.GameId == id);

                if (viewModel.Game == null)
                {
                    return NotFound(); // If the game doesn't exist, show a not found page.
                }

                // Set selected IDs based on existing data
                viewModel.SelectedCategoryIds = viewModel.Game.GameDetailsCategories.Select(gdc => gdc.CategoryId).ToList();
                viewModel.SelectedLanguageIds = viewModel.Game.GameDetailsLanguages.Select(gdl => gdl.LanguageId).ToList();
                viewModel.SelectedPlatformIds = viewModel.Game.GameDetailsPlatforms.Select(gdp => gdp.PlatformId).ToList();
                if(ViewBag.Title != "Game Details")
                {
                    ViewBag.Title = "Save Changes";
                    returnView = "Edit";
                }
                else
                {
                    returnView = "Details";
                }
                
            }

            if (returnView == "Edit")
            {
                // Load the checkbox data for categories, languages, and platforms
                viewModel.Categories = await _SVGSDbContext.GameCategories.ToListAsync();
                viewModel.Languages = await _SVGSDbContext.LanguageTables.ToListAsync();
                viewModel.Platforms = await _SVGSDbContext.GamePlatforms.ToListAsync();
            }
            else
            {
                // Load only the selected categories, languages, and platforms based on selected IDs
                viewModel.Categories = await _SVGSDbContext.GameCategories
                                            .Where(c => viewModel.SelectedCategoryIds.Contains(c.CategoryId))
                                            .ToListAsync();

                viewModel.Languages = await _SVGSDbContext.LanguageTables
                                            .Where(l => viewModel.SelectedLanguageIds.Contains(l.LanguageId))
                                            .ToListAsync();

                viewModel.Platforms = await _SVGSDbContext.GamePlatforms
                                            .Where(p => viewModel.SelectedPlatformIds.Contains(p.PlatformId))
                                            .ToListAsync();
                string imagePath = "wwwroot/Imgs/Games/" + viewModel.Game.GameName.ToString() + ".jpg";

                if (!System.IO.File.Exists(imagePath))
                {
                    ViewBag.ImgPath = "Imgs/Games/placeholder440x530.jpg";  // Path to your placeholder image
                }
                else
                {
                    ViewBag.ImgPath = "Imgs/Games/" + viewModel.Game.GameName.ToString() + ".jpg";
                }
            }
            

            return View(returnView, viewModel); // return view is either returning edit view or details view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveEditGame(EditGameViewModel viewModel)
        {
            viewModel.Categories = await _SVGSDbContext.GameCategories.ToListAsync();
            viewModel.Languages = await _SVGSDbContext.LanguageTables.ToListAsync();
            viewModel.Platforms = await _SVGSDbContext.GamePlatforms.ToListAsync();

            // Manually validate that at least one item is selected for each
            if (viewModel.SelectedCategoryIds == null || !viewModel.SelectedCategoryIds.Any())
            {
                ModelState.AddModelError("SelectedCategoryIds", "Please select at least one category.");
            }
            if (viewModel.SelectedLanguageIds == null || !viewModel.SelectedLanguageIds.Any())
            {
                ModelState.AddModelError("SelectedLanguageIds", "Please select at least one language.");
            }
            if (viewModel.SelectedPlatformIds == null || !viewModel.SelectedPlatformIds.Any())
            {
                ModelState.AddModelError("SelectedPlatformIds", "Please select at least one platform.");
            }

            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                // output errors to console of modelstate
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }

                ViewBag.Title = viewModel.Game.GameId == 0 ? "Add New Game" : "Save Changes";

                return View("Edit", viewModel);
            }

            // Output all form data to diagnose
            foreach (var key in Request.Form.Keys)
            {
                Console.WriteLine($"Form Key: {key}, Value: {Request.Form[key]}");
            }

            // Manually bind the radio button value to the Game.PhysicalAvailable property
            if (Request.Form.ContainsKey("Game.PhysicalAvailable"))
            {
                // Parse the value from the form submission
                string physicalAvailableValue = Request.Form["Game.PhysicalAvailable"];
                viewModel.Game.PhysicalAvailable = physicalAvailableValue == "true";
            }

            // Check if this is a new game (GameId is 0 or not set)
            if (viewModel.Game.GameId == 0)
            {
                // Adding a new game
                _SVGSDbContext.Games.Add(viewModel.Game);
                await _SVGSDbContext.SaveChangesAsync();

                // Now add the associated categories, languages, and platforms
                await UpdateGameDetails(viewModel.Game.GameId, viewModel);
            }
            else
            {
                // Update existing game
                var existingGame = await _SVGSDbContext.Games
                    .Include(g => g.GameDetailsCategories)
                    .Include(g => g.GameDetailsLanguages)
                    .Include(g => g.GameDetailsPlatforms)
                    .FirstOrDefaultAsync(g => g.GameId == viewModel.Game.GameId);

                if (existingGame == null)
                {
                    return NotFound();
                }

                // Update the game properties
                existingGame.GameName = viewModel.Game.GameName;
                existingGame.Details = viewModel.Game.Details;
                existingGame.Price = viewModel.Game.Price;
                existingGame.PhysicalAvailable = viewModel.Game.PhysicalAvailable;
                existingGame.IsDeleted = viewModel.Game.IsDeleted;

                // Save changes to the game
                _SVGSDbContext.Games.Update(existingGame);
                await _SVGSDbContext.SaveChangesAsync();

                // Update game details (categories, languages, platforms)
                await UpdateGameDetails(existingGame.GameId, viewModel);
            }

            // Redirect to the list or detail page after saving
            return RedirectToAction(nameof(List));
        }

        private async Task UpdateGameDetails(int gameId, EditGameViewModel viewModel)
        {
            // Remove existing entries in GameDetailsCategory, GameDetailsLanguage, and GameDetailsPlatform for this game
            var existingCategories = _SVGSDbContext.GameDetailsCategories.Where(gdc => gdc.GameId == gameId);
            var existingLanguages = _SVGSDbContext.GameDetailsLanguages.Where(gdl => gdl.GameId == gameId);
            var existingPlatforms = _SVGSDbContext.GameDetailsPlatforms.Where(gdp => gdp.GameId == gameId);

            _SVGSDbContext.GameDetailsCategories.RemoveRange(existingCategories);
            _SVGSDbContext.GameDetailsLanguages.RemoveRange(existingLanguages);
            _SVGSDbContext.GameDetailsPlatforms.RemoveRange(existingPlatforms);
            await _SVGSDbContext.SaveChangesAsync();

            // Add new entries based on the selected IDs in the view model
            if (viewModel.SelectedCategoryIds != null)
            {
                foreach (var categoryId in viewModel.SelectedCategoryIds)
                {
                    var gameCategory = new GameDetailsCategory
                    {
                        GameId = gameId,
                        CategoryId = categoryId
                    };
                    _SVGSDbContext.GameDetailsCategories.Add(gameCategory);
                }
            }

            if (viewModel.SelectedLanguageIds != null)
            {
                foreach (var languageId in viewModel.SelectedLanguageIds)
                {
                    var gameLanguage = new GameDetailsLanguage
                    {
                        GameId = gameId,
                        LanguageId = languageId
                    };
                    _SVGSDbContext.GameDetailsLanguages.Add(gameLanguage);
                }
            }

            if (viewModel.SelectedPlatformIds != null)
            {
                foreach (var platformId in viewModel.SelectedPlatformIds)
                {
                    var gamePlatform = new GameDetailsPlatform
                    {
                        GameId = gameId,
                        PlatformId = platformId
                    };
                    _SVGSDbContext.GameDetailsPlatforms.Add(gamePlatform);
                }
            }

            // Save the changes to the database
            await _SVGSDbContext.SaveChangesAsync();
        }

        //---------------------------------------Hard deleting a game from database---------------------------------
        //[HttpGet("Games/Delete/{id}")]
        //public async Task<IActionResult> HardDeleteConfirmed(int id)
        //{
        //    //----This is the hard delete version
        //    // Find the game entity using its ID
        //    var game = await _SVGSDbContext.Games
        //        .Include(g => g.GameDetailsCategories)
        //        .Include(g => g.GameDetailsLanguages)
        //        .Include(g => g.GameDetailsPlatforms)
        //        .FirstOrDefaultAsync(g => g.GameId == id);

        //    if (game == null)
        //    {
        //        return NotFound();
        //    }

        //    // Remove related GameDetailsCategory entries
        //    if (game.GameDetailsCategories != null && game.GameDetailsCategories.Any())
        //    {
        //        _SVGSDbContext.GameDetailsCategories.RemoveRange(game.GameDetailsCategories);
        //    }

        //    // Remove related GameDetailsLanguage entries
        //    if (game.GameDetailsLanguages != null && game.GameDetailsLanguages.Any())
        //    {
        //        _SVGSDbContext.GameDetailsLanguages.RemoveRange(game.GameDetailsLanguages);
        //    }

        //    // Remove related GameDetailsPlatform entries
        //    if (game.GameDetailsPlatforms != null && game.GameDetailsPlatforms.Any())
        //    {
        //        _SVGSDbContext.GameDetailsPlatforms.RemoveRange(game.GameDetailsPlatforms);
        //    }

        //    // Finally, remove the game entity itself
        //    _SVGSDbContext.Games.Remove(game);

        //    // Save changes to the database
        //    await _SVGSDbContext.SaveChangesAsync();

        //    // Redirect to the list of games after deletion
        //    return RedirectToAction(nameof(List));

        //}

        // POST: soft deleting game
        [HttpPost("Games/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            //-------This is the soft delete version------------------------
            // Find the game entity using its ID
            var game = await _SVGSDbContext.Games
                .Include(g => g.GameDetailsCategories)
                .Include(g => g.GameDetailsLanguages)
                .Include(g => g.GameDetailsPlatforms)
                .FirstOrDefaultAsync(g => g.GameId == id);

            if (game == null)
            {
                return NotFound();
            }

            // Instead of deleting, mark the game as soft-deleted
            game.IsDeleted = true;

            // Update the game entity in the database context
            _SVGSDbContext.Games.Update(game);

            // Save changes to the database
            await _SVGSDbContext.SaveChangesAsync();

            // Redirect to the list of games after soft deletion
            return RedirectToAction(nameof(List));
        }

        private bool GameExists(int id)
        {
            return _SVGSDbContext.Games.Any(e => e.GameId == id);
        }
    }
}
