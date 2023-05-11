using InterfaceLayer;
using DataAccessLayerOrbis;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace FactoryLayerOrbis
{
    public class Factory
    {
        public static IWorldInterface GetWorldInterface()
        {
            //IWorldInterface dal = new DatabaseOrbis();

            return dal;
        }
    }
}