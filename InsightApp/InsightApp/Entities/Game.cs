using System.ComponentModel.DataAnnotations;

namespace InsightApp.Entities
{
    public class Game
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int GameId { get; set; }

        [Required(ErrorMessage = "Please enter the game name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the game detail")]
        public string Details { get; set; }
        public float Price { get; set; } = 0; //default value
        public bool? IsDeleted { get; set; } = false; //default value
        public int CategoryId { get; set; } //FK
        public Category? Category { get; set; } //add a full Category object as a 2nd prop

        //public ICollection<Review>? Review { get; set; } // Nav to all reviews
        //public ICollection<WishList>? WishList { get; set; } // Nav to all games as in wish list
        public ICollection<OrderItem>? OrderItem { get; set; } // Nav to all order items
        public ICollection<GameLanguage>? GameLanguage { get; set; } // Nav to all game languages
        public ICollection<GamePlatform>? GamePlatform { get; set; } // Nav to all game platforms

    }
}
