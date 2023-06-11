using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLayerOrbis
{
    [Serializable]
    public class FactoryFatalException : Exception
    {
        public FactoryFatalException()
        {
            
        }

        public FactoryFatalException(string message) : base(message) 
        { 
        
        }
    }
}
