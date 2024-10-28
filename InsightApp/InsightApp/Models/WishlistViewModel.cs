using InsightApp.Entities;

namespace InsightApp.Models
{
    public class WishlistViewModel
    {
        public List<Game> WishlistItems { get; set; } = new List<Game>();
        public int MemberId { get; set;}
    }
}
