using InsightApp.Entities;
using InsightApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InsightApp.Controllers
{
    public class ProductController : Controller
    {
        private InsightUpdateCvgs2Context _SVGSDbContext;
        public ProductController(InsightUpdateCvgs2Context sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }

        [HttpGet("Portal/product-details")]
        public async Task<IActionResult> details(int id)
        {

            return View();
        }
        
        [HttpGet("Portal/products")]
        public async Task<IActionResult> products(GamesListModel gamesListModel)
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
                                            GameImageLink = g.GameImageLink,
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
                        GameImageLink = g.GameImageLink,
                        Categories = g.GameDetailsCategories
                            .Where(gdc => gdc.Category != null)
                            .Select(gdc => gdc.Category.CategoryName)
                            .ToList()
                    })
                    .OrderBy(g => g.GameName)
                    .ToListAsync();

                gamesListModel.GamesList = allGames;

            }

            return View("products", gamesListModel);
        }

        [HttpGet("Portal/cart")]
        public async Task<IActionResult> cart()
        {
            return View();
        }

        [HttpGet("Portal/cart/checkout")]
        public async Task<IActionResult> checkout()
        {
            return View();
        }
    }
}
