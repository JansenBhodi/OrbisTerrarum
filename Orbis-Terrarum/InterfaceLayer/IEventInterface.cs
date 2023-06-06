using InterfaceLayerOrbis.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerOrbis
{
    public interface IEventInterface
    {
        List<DbEvent> GetEventsByWorld(int id);
        DbEvent GetEventById(int id);
        List<DbEvent> GetEventsByCharacter(int id);
        void CreateEvent(DbEvent dbEvent);
        void UpdateEvent(DbEvent dbEvent);
        void DeleteEvent(DbEvent dbEvent);

    }
}
