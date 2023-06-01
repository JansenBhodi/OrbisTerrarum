using System.Data;
using System.Data.SqlClient;
using InterfaceLayer;
using InterfaceLayerOrbis;
using InterfaceLayerOrbis.DbClasses;


namespace DataAccessLayerOrbis
{
    public class Database : IUserInterface, IWorldInterface, ICharacterInterface, IEventInterface
    {
        DbConn dbConn = new DbConn();

        public void CreateWorld(DbWorld world)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "INSERT INTO World (WorldName) VALUES (@WorldName)";
            command.Parameters.AddWithValue("@WorldName", world.WorldName);

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        public List<DbWorld> GetAllWorlds()
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM World";

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<DbWorld> result = new List<DbWorld>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DbWorld world = new DbWorld();
                world.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                world.WorldName = dt.Rows[i]["WorldName"].ToString();
                world.WorldCurrentYear = Convert.ToDateTime(dt.Rows[i]["WorldCurrentYear"]);
                world.WorldDesc = dt.Rows[i]["WorldDesc"].ToString();
                world.CreatorId = Convert.ToInt32(dt.Rows[i]["CreatorId"]);
                result.Add(world);
            }

            return result;
        }

        public DbWorld GetWorldById(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM World WHERE Id = @id";
            command.Parameters.Add("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            DbWorld result = new DbWorld();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                result.WorldName = dt.Rows[i]["WorldName"].ToString();
                result.WorldCurrentYear = Convert.ToDateTime(dt.Rows[i]["WorldCurrentYear"]);
                result.WorldDesc = dt.Rows[i]["WorldDesc"].ToString();
                result.CreatorId = Convert.ToInt32(dt.Rows[i]["CreatorId"]);
            }

            return result;
        }

        public DbUser GetUserByCreatorId(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM User WHERE Id = @creatorId";
            command.Parameters.Add("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            DbUser result = new DbUser();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                result.Email = dt.Rows[i]["Email"].ToString();
                result.Password = dt.Rows[i]["Password"].ToString();
                result.IsCreator = Convert.ToBoolean(dt.Rows[i]["WorldDesc"]);
            }

            return result;
        }



        public bool LoginCheck(string email, string password)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM User " +
                                  "WHERE `UserEmail` = @email AND `UserPassword` = @password";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            int check = int.Parse(command.ExecuteScalar().ToString());
            if (check == 1) 
            {
                return true;
            }
            return false;
        }
    }
}
