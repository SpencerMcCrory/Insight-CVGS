namespace InsightApp.Entities
{
    public class EventType
    {
        public string EvTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Event>? Events { get; set; } // Nav to all Events of this type
    }
}
