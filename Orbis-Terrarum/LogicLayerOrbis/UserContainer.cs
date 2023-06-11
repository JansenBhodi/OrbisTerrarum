using FactoryLayerOrbis;
using InterfaceLayerOrbis;
using InterfaceLayerOrbis.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis
{
    public class UserContainer
    {
        private IUserInterface _userInterface = Factory.GetUserInterface();
        public bool TryLogin(string username, string password)
        {
            bool result = new bool();

            result = _userInterface.LoginCheck(username, password);

            return result;
        }

        public User GetUserByCreatorId(int id)
        {
            DbUser user = new DbUser();
            try
            {
                user = _userInterface.GetUserByCreatorId(id);
            }
            catch (Exception)
            {

                throw;
            }

            User result = new User(user.Id, user.Email, user.Password, user.IsCreator);

            return result;
        }
    }
}
