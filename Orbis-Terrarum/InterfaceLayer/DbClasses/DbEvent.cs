namespace InterfaceLayerOrbis.DbClasses
{
    public class DbEvent
    {

        public int EventId { get;  set; }
        public int WorldId { get;  set; }
        public string EventName { get;  set; }
        public string EventDescription { get;  set; }
        public bool EventResolved { get;  set; }
        public DateOnly EventStart { get;  set; }
        public DateOnly EventEnd { get;  set; }
    }
}
