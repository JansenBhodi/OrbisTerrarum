using FactoryLayerOrbis;
using InterfaceLayerOrbis;
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
    }
}
