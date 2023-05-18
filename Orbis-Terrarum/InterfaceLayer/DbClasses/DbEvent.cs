namespace InterfaceLayerOrbis.DbClasses
{
    public class DbEvent
    {
        public DbEvent()
        {

        }

        public int EventId { get; private set; }
        public int WorldId { get; private set; }
        public string EventName { get; private set; }
        public string EventDescription { get; private set; }
        public bool EventResolved { get; private set; }
        public DateOnly EventStart { get; private set; }
        public DateOnly EventEnd { get; private set; }
    }
}
