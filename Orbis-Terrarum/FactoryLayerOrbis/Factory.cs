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
            IWorldInterface dal = new Database();

            return dal;
        }

        public static IUserInterface GetUserInterface()
        {
            IUserInterface dal = new Database();

            return dal;
        }
    }
}