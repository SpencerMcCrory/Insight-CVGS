using InsightApp.Entities;

namespace InsightApp.Models
{
    public class OwnedGamesViewModel
    {
        public List<Game> MyGamesItems { get; set; } = new List<Game>();
        public int MemberId { get; set;}
    }
}
