using InterfaceLayer;
using DataAccessLayerOrbis;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using InterfaceLayerOrbis;

namespace FactoryLayerOrbis
{
    public class Factory
    {
        public static IWorldInterface GetWorldInterface()
        {
            try
            {
                IWorldInterface dal = new Database();

                return dal;
            }
            catch (Exception)
            {
                throw new FactoryFatalException("Couldn't create the specified Interface: World");
            }
        }

        public static IUserInterface GetUserInterface()
        {
            
            try
            {
                IUserInterface dal = new Database();

                return dal;
            }
            catch (Exception)
            {
                throw new FactoryFatalException("Couldn't create the specified Interface: User");
            }
        }

        public static IEventInterface GetEventInterface()
        {
            
            try
            {
                IEventInterface dal = new Database();

                return dal;
            }
            catch (Exception)
            {
                throw new FactoryFatalException("Couldn't create the specified Interface: Event");
            }
        }

        public static ICharacterInterface GetCharacterInterface()
        {
            
            try
            {
                ICharacterInterface dal = new Database();

                return dal;
            }
            catch (Exception)
            {
                throw new FactoryFatalException("Couldn't create the specified Interface: Character");
            }
        }
    }
}