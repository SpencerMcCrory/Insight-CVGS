using System.ComponentModel.DataAnnotations;

namespace InsightApp.Entities
{
    public class Game
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int GameId { get; set; }

        [Required(ErrorMessage = "Please enter the game name")]
        public string GameName { get; set; }

        [Required(ErrorMessage = "Please enter the game detail")]
        public string Details { get; set; }
        public float Price { get; set; } = 0; //default value
        public bool? IsDeleted { get; set; } = false; //default value
        public bool? PhysicalAvailable { get; set; } = true;//default value
        public ICollection<Review>? Reviews { get; set; } // Nav to all reviews
        public ICollection<WishList>? WishLists { get; set; } // Nav to all games as in wish list
        public ICollection<OrderItem>? OrderItems { get; set; } // Nav to all order items
        public ICollection<GameDetailsLanguage>? GameDetailsLanguages { get; set; } // Nav to all game languages
        public ICollection<GameDetailsPlatform>? GameDetailsPlatforms { get; set; } // Nav to all game platforms
        public ICollection<GameDetailsCategory>? GameDetailsCategorys { get; set; } // Nav to all game categories

    }
}
