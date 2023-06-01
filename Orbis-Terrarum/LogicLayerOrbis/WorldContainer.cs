using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryLayerOrbis;
using InterfaceLayer;
using InterfaceLayerOrbis.DbClasses;
using Microsoft.Identity.Client;

namespace LogicLayerOrbis
{
    public class WorldContainer
    {
        IWorldInterface iWorld = Factory.GetWorldInterface();

        //World Functions

        public List<World> GetWorlds()
        {
            List<World> result = new List<World>();

            List<DbWorld> test = iWorld.GetAllWorlds();

            foreach(DbWorld db in test) 
            {
                if(db.WorldDesc != null)
                {
                    World world = new World(db.Id, db.WorldName, DateOnly.FromDateTime(db.WorldCurrentYear), db.WorldDesc, db.CreatorId);
                    result.Add(world);
                }
                else
                {
                    World world = new World(db.Id, db.WorldName, DateOnly.FromDateTime(db.WorldCurrentYear), db.CreatorId);
                    result.Add(world);
                }
                
            }

            return result;
        }
        
        public World GetWorldById(int id)
        {
            DbWorld world = new DbWorld();

            world = iWorld.GetWorldById(id);
            World result = new World(world.Id, world.WorldName, DateOnly.FromDateTime(world.WorldCurrentYear), world.WorldDesc, world.CreatorId);

            return result;
        }
    }
}
