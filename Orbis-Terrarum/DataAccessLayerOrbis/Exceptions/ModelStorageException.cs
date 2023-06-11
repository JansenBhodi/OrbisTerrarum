using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOrbis.Exceptions
{
    public class ModelStorageException : Exception
    {
        public ModelStorageException() { }

        public ModelStorageException(string message) : base(message) { }
    }
}
