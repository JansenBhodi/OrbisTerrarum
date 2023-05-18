using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryLayerOrbis;
using InterfaceLayer;
using InterfaceLayerOrbis.DbClasses;

namespace LogicLayerOrbis
{
    public class WorldContainer
    {
        IWorldInterface iWorld = Factory.GetWorldInterface();
        
        public List<World> GetWorlds()
        {
            List<World> result = new List<World>();

            

            return result;
        }
        
        //World Functions
    }
}
