using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryLayerOrbis;
using InterfaceLayer;
using InterfaceLayerOrbis.DbClasses;
using Microsoft.Identity.Client;
using LogicLayerOrbis.Exceptions;

namespace LogicLayerOrbis
{
    public class WorldContainer
    {
        IWorldInterface iWorld = Factory.GetWorldInterface();

        //World Functions

        public List<World> GetWorlds()
        {
            List<World> result = new List<World>();
            List<DbWorld> response = new List<DbWorld>();

            try
            {
                response = iWorld.GetAllWorlds();
            }
            catch (Exception)
            {

                throw;
            }

            foreach(DbWorld db in response) 
            {
                try
                {
                    if (db.WorldDesc != null)
                    {
                        World world = new World(db.Id, db.WorldName, DateOnly.FromDateTime(db.WorldCurrentYear), db.WorldDesc, db.CreatorId);
                        result.Add(world);
                    }
                    else
                    {

                        World world = new World(db.Id, db.WorldName, DateOnly.FromDateTime(db.WorldCurrentYear), "", db.CreatorId);
                        result.Add(world);
                    }
                }
                catch (Exception)
                {

                    throw new CreateItemListException("Failed to translate database entry to model. Check differences between model and database.");
                }
                
            }

            return result;
        }
        
        public World GetWorldById(int id)
        {
            DbWorld world = new DbWorld();

            try
            {
                world = iWorld.GetWorldById(id);
            }
            catch (Exception)
            {

                throw;
            }

            World result = new World(world.Id, world.WorldName, DateOnly.FromDateTime(world.WorldCurrentYear), world.WorldDesc, world.CreatorId);

            return result;
        }

        public void CreateWorld(World world)
        {
            DbWorld newWorld = new DbWorld();

            newWorld.WorldDesc = world.WorldDesc;
            newWorld.CreatorId = world.CreatorId;
            newWorld.WorldName = world.WorldName;
            newWorld.WorldCurrentYear = world.WorldCurrentYear.ToDateTime(TimeOnly.MinValue);

            try
            {
                iWorld.CreateWorld(newWorld);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EditWorld(World world)
        {
            DbWorld Update = new DbWorld();

            Update.WorldDesc = world.WorldDesc;
            Update.CreatorId = world.CreatorId;
            Update.WorldName = world.WorldName;
            Update.WorldCurrentYear = world.WorldCurrentYear.ToDateTime(TimeOnly.MinValue);
            Update.Id = world.Id;

            try
            {
                iWorld.UpdateWorld(Update);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteWorld(World world)
        {
            DbWorld Target = new DbWorld();
            Target.Id= world.Id;
            Target.CreatorId = world.CreatorId;

            try
            {
                iWorld.DeleteWorld(Target);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
