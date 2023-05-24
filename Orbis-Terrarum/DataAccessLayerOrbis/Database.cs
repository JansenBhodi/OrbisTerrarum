﻿using System.Data;
using System.Data.SqlClient;
using InterfaceLayer;
using InterfaceLayerOrbis;
using InterfaceLayerOrbis.DbClasses;


namespace DataAccessLayerOrbis
{
    public class Database : IUserInterface, IWorldInterface
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

        public bool LoginCheck(string email, string password)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM User " +
                                  "WHERE `UserEmail` = @email AND `UserPassword` = @password";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            int check = command.ExecuteScalar();
            if (check == 1) 
            {
                return true;
            }
            return false;
        }
    }
}