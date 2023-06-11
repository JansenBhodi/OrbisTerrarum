using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOrbis.Exceptions
{
    public class CommandCreateException : Exception
    {
        public CommandCreateException() { }

        public CommandCreateException(string message) : base(message) { }
    }
}
