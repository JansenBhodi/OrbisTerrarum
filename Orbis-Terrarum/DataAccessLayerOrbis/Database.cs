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

        #region WorldFunctions
        public void CreateWorld(DbWorld world)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "INSERT INTO World (WorldName, WorldCurrentYear, WorldDesc, CreatorId) VALUES (@WorldName, @WorldCurrentYear, @WorldDesc, @CreatorId)";
            command.Parameters.AddWithValue("@WorldName", world.WorldName);
            command.Parameters.AddWithValue("@WorldCurrentYear", world.WorldCurrentYear);
            command.Parameters.AddWithValue("@WorldDesc", world.WorldDesc);
            command.Parameters.AddWithValue("@CreatorId", world.CreatorId);

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
            command.Parameters.AddWithValue("@id", id);

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

        public void UpdateWorld(DbWorld world)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "UPDATE World SET WorldName = @worldName, WorldCurrentYear = @worldCurrentYear, WorldDesc = @worldDesc WHERE Id = @id";
            command.Parameters.AddWithValue("@worldName", world.WorldName);
            command.Parameters.AddWithValue("@worldCurrentYear", world.WorldCurrentYear);
            command.Parameters.AddWithValue("@worldDesc", world.WorldDesc);
            command.Parameters.AddWithValue("@id", world.Id);

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        public void DeleteWorld(DbWorld world)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "DELETE FROM World WHERE Id = @id";
            command.Parameters.AddWithValue("@id", world.Id);

            command.ExecuteNonQuery();

            command.CommandText = "UPDATE " + '"' + "User" +'"' + " SET UserIsCreator = 0 WHERE Id = @id";
            command.Parameters.AddWithValue("@id", world.CreatorId);

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        #endregion

        #region UserFunctions
        public DbUser GetUserByCreatorId(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM " + '"' + "User" + '"' + " WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            DbUser result = new DbUser();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                result.Email = dt.Rows[i]["UserEmail"].ToString();
                result.Password = dt.Rows[i]["UserPassword"].ToString();
                result.IsCreator = Convert.ToBoolean(dt.Rows[i]["UserIsCreator"]);
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

        public List<DbUser> GetNonCreatorUsers()
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM " + '"' + "User" + '"' + " WHERE UserIsCreator = 0";

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<DbUser> result = new List<DbUser>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DbUser user = new DbUser();
                user.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                user.Email = dt.Rows[i]["UserEmail"].ToString();
                user.IsCreator = Convert.ToBoolean(dt.Rows[i]["UserIsCreator"]);
                user.Password = dt.Rows[i]["UserPassword"].ToString();
                result.Add(user);
            }

            return result;
        }

        #endregion
    }
}
