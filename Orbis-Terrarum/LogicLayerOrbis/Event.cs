using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis
{
    public class Event
    {
        public int EventId { get; set; }
        public int WorldId { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public bool EventResolved { get; set; }
        public DateOnly EventStart { get; set; }
        public DateOnly EventEnd { get; set; }

        public Event (int id, int worldId, string eventName, string eventDesc, bool eventResolved, DateOnly eventStart, DateOnly eventEnd)
        {
            EventId = id;
            WorldId = worldId;
            EventName = eventName;
            EventDescription = eventDesc;
            EventResolved = eventResolved;
            EventStart = eventStart;
            EventEnd = eventEnd;
        }

        public void UpdateEvent(string eventName, string eventDesc, bool eventResolved, DateOnly eventStart, DateOnly eventEnd)
        {
            EventName = eventName;
            EventDescription = eventDesc;
            EventResolved = eventResolved;
            EventStart = eventStart;
            EventEnd = eventEnd;
        }
    }
}
