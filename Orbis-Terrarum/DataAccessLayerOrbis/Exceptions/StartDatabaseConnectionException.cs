using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOrbis.Exceptions
{
    public class StartDatabaseConnectionException : Exception
    {
        public StartDatabaseConnectionException()
        {

        }

        public StartDatabaseConnectionException(string message) : base(message) 
        { 
        
        }
    }
}
