namespace InsightApp.Entities
{
    public class Category
    {
        // EF Core will configure this to be an auto-incremented primary key:
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Game>? Game { get; set; }
        public ICollection<MemberGameCategoryPref>? MemberGameCategoryPref { get; set; }
        public ICollection<GameCategory>? GameCategory { get; set; }

    }
}
