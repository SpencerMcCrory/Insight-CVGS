namespace InsightApp.Entities
{
    public class EventType
    {
        public int EvTypeId { get; set; }
        public string EvTypeName { get; set; }

        public ICollection<GameEvent>? Events { get; set; } // Nav to all Events of this type
    }
}
