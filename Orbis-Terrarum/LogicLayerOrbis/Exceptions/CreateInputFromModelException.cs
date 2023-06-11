using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis.Exceptions
{
    public class CreateInputFromModelException : Exception
    {
        public CreateInputFromModelException() { }

        public CreateInputFromModelException(string message) : base(message) { }
    }
}
