using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis
{
    public class User
    {
        public User(int id, string email, string password, bool isCreator)
        {
            Id = id;
            Email = email;
            Password = password;
            IsCreator = isCreator;
        }

        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsCreator { get; private set; }

        public void BecomeCreator()
        {
            IsCreator = true;
        }

        public void UpdateUser()
        {

        }
    }
}
