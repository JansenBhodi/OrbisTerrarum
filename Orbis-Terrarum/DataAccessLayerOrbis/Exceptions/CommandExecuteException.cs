using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOrbis.Exceptions
{
    public class CommandExecuteException : Exception
    {
        public CommandExecuteException() { }

        public CommandExecuteException(string message) : base(message) { }
    }
}
