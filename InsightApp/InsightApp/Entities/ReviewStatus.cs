namespace InsightApp.Entities
{
    public class ReviewStatus
    {
        public int StatusId { get; set; }
        public string Statusname { get; set; }

        public ICollection<Review>? Reviews { get; set; } // Nav to all Reviews of this type
    }
}
