namespace InsightApp.Entities
{
    public class GameCategory
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Game>? Game { get; set; }
        public ICollection<MemberGameCategoryPref>? MemberGameCategoryPrefs { get; set; }
        public ICollection<GameDetailsCategory>? GameDetailsCategorys { get; set; }

    }
}
