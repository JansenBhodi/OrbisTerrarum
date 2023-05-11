namespace DataAccessLayerOrbis
{
    public class DbUser
    {

        public DbUser(int id, string email, string password, bool isCreator)
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

    }
}
