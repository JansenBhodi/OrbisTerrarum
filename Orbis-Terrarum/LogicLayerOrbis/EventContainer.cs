using FactoryLayerOrbis;
using InterfaceLayerOrbis;
using InterfaceLayerOrbis.DbClasses;
using LogicLayerOrbis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis
{
    public class EventContainer
    {
        IEventInterface eventInterface = Factory.GetEventInterface();

        public List<Event> GetEventsByWorld(int id)
        {
            List<Event> events = new List<Event>();
            List<DbEvent> db = new List<DbEvent>();

            try
            {
                db = eventInterface.GetEventsByWorld(id);
            }
            catch (Exception)
            {

                throw;
            }

            foreach (DbEvent item in db)
            {
                try
                {
                    Event input = new Event(item.EventId, item.WorldId, item.EventName, item.EventDescription, item.EventResolved, item.EventStart, item.EventEnd);
                    events.Add(input);
                }
                catch (Exception)
                {

                    throw new CreateItemListException("Couldn't create new item in model. Check database input");
                }
            }

            return events;
        }

        public List<Event> GetEventsByCharacter(int id)
        {
            List<Event> events = new List<Event>();
            List<DbEvent> db = new List<DbEvent>();

            try
            {
                db = eventInterface.GetEventsByCharacter(id);
            }
            catch (Exception)
            {

                throw;
            }

            foreach (DbEvent item in db)
            {
                try
                {
                    Event input = new Event(item.EventId, item.WorldId, item.EventName, item.EventDescription, item.EventResolved, item.EventStart, item.EventEnd);
                    events.Add(input);
                }
                catch (Exception)
                {

                    throw new CreateItemListException("Couldn't create new item in model. Check database input");
                }
            }

            return events;
        }

        public Event GetEventById(int id) 
        {
            DbEvent db = new DbEvent();

            try
            {
                db = eventInterface.GetEventById(id);
            }
            catch (Exception)
            {

                throw;
            }

            Event result = new Event(db.EventId, db.WorldId, db.EventName, db.EventDescription, db.EventResolved, db.EventStart, db.EventEnd);

            return result;
        }

        public void CreateEvent(Event input)
        {
            DbEvent db = new DbEvent();

            try
            {
                db.EventId = input.EventId;
                db.WorldId = input.WorldId;
                db.EventName = input.EventName;
                db.EventDescription = input.EventDescription;
                db.EventResolved = input.EventResolved;
                db.EventStart = input.EventStart;
                db.EventEnd = input.EventEnd;
            }
            catch (Exception)
            {

                throw new CreateInputFromModelException("Couldn't properly convert model entry into database class.");
            }

            try
            {
                eventInterface.CreateEvent(db);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditEvent(Event input)
        {
            DbEvent db = new DbEvent();

            try
            {
                db.EventId = input.EventId;
                db.WorldId = input.WorldId;
                db.EventName = input.EventName;
                db.EventDescription = input.EventDescription;
                db.EventResolved = input.EventResolved;
                db.EventStart = input.EventStart;
                db.EventEnd = input.EventEnd;
            }
            catch (Exception)
            {

                throw new CreateInputFromModelException("Couldn't properly convert model entry into database class.");
            }

            try
            {
                eventInterface.UpdateEvent(db);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void DeleteEvent(int id) 
        {
            DbEvent db = new DbEvent();

            db.EventId = id;

            try
            {
                eventInterface.DeleteEvent(db);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
