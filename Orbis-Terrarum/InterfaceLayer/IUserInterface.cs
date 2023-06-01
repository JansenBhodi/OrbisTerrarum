using InterfaceLayerOrbis.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerOrbis
{
    public interface IUserInterface
    {
        public bool LoginCheck(string email, string password);
        public DbUser GetUserByCreatorId(int id);
    }
}
