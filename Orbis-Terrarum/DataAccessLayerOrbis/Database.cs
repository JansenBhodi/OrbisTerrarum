﻿using System;
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
            dbConn.ConnString.Close();

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
            dbConn.ConnString.Close();

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

            command.CommandText = "UPDATE " + '"' + "User" +'"' + " SET UserIsCreator = 0 WHERE Id = @creatorId";
            command.Parameters.AddWithValue("@creatorId", world.CreatorId);

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

            dbConn.ConnString.Close();
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
            dbConn.ConnString.Close();
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

            dbConn.ConnString.Close();
            return result;
        }

        #endregion

        #region CharacterFunctions

        public List<DbCharacter> GetCharactersByWorld(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Character WHERE WorldId = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<DbCharacter> result = new List<DbCharacter>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DbCharacter character = new DbCharacter();
                character.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                character.WorldId = Convert.ToInt32(dt.Rows[i]["WorldId"]);
                character.CharacterName = dt.Rows[i]["CharacterName"].ToString();
                character.CharacterDesc = dt.Rows[i]["CharacterDesc"].ToString();
                character.CharacterAge = Convert.ToInt32(dt.Rows[i]["CharacterAge"]);
                character.CharacterAlignment = Convert.ToInt32(dt.Rows[i]["CharacterAlignment"]);
                result.Add(character);
            }
            dbConn.ConnString.Close();

            return result;
        }

        public DbCharacter GetCharacterById(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Character WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            DbCharacter result = new DbCharacter();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                result.WorldId = Convert.ToInt32(dt.Rows[i]["WorldId"]);
                result.CharacterName = dt.Rows[i]["CharacterName"].ToString();
                result.CharacterDesc = dt.Rows[i]["CharacterDesc"].ToString();
                result.CharacterAge = Convert.ToInt32(dt.Rows[i]["CharacterAge"]);
                result.CharacterAlignment = Convert.ToInt32(dt.Rows[i]["CharacterAlignment"]);
            }
            dbConn.ConnString.Close();

            return result;
        }

        public List<DbCharacter> GetCharactersByEvent(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT e.EventId, c.* FROM EventCharacter e INNER JOIN Character c ON e.CharacterId = c.Id WHERE e.EventId = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<DbCharacter> result = new List<DbCharacter>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DbCharacter character = new DbCharacter();
                character.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                character.WorldId = Convert.ToInt32(dt.Rows[i]["WorldId"]);
                character.CharacterName = dt.Rows[i]["CharacterName"].ToString();
                character.CharacterDesc = dt.Rows[i]["CharacterDesc"].ToString();
                character.CharacterAge = Convert.ToInt32(dt.Rows[i]["CharacterAge"]);
                character.CharacterAlignment = Convert.ToInt32(dt.Rows[i]["CharacterAlignment"]);
                result.Add(character);
            }
            dbConn.ConnString.Close();

            return result;
        }

        public void CreateCharacter(DbCharacter character)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "INSERT INTO Character (WorldId, CharacterName, CharacterAge, CharacterDesc, CharacterAlignment) VALUES (@worldId, @CharacterName, @CharacterAge, @CharacterDesc, @CharacterAlignment)";
            command.Parameters.AddWithValue("@WorldId", character.WorldId);
            command.Parameters.AddWithValue("@CharacterName", character.CharacterName);
            command.Parameters.AddWithValue("@CharacterAge", character.CharacterAge);
            command.Parameters.AddWithValue("@CharacterDesc", character.CharacterDesc);
            command.Parameters.AddWithValue("@CharacterAlignment", character.CharacterAlignment);

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        public void UpdateCharacter(DbCharacter character)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "UPDATE Character SET CharacterName = @CharacterName, CharacterAge = @CharacterAge, CharacterDesc = @CharacterDesc, CharacterAlignment = @CharacterAlignment WHERE Id = @id";
            command.Parameters.AddWithValue("@CharacterName", character.CharacterName);
            command.Parameters.AddWithValue("@CharacterAge", character.CharacterAge);
            command.Parameters.AddWithValue("@CharacterDesc", character.CharacterDesc);
            command.Parameters.AddWithValue("@CharacterAlignment", character.CharacterAlignment);

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        public void DeleteCharacter(DbCharacter character)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "DELETE FROM EventCharacter WHERE CharacterId = @id";
            command.Parameters.AddWithValue("@id", character.Id);

            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM Character WHERE Id = @id";

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        #endregion

        #region EventFunctions
        public List<DbEvent> GetEventsByWorld(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Event WHERE WorldId = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<DbEvent> result = new List<DbEvent>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DbEvent dbEvent = new DbEvent();
                dbEvent.EventId = Convert.ToInt32(dt.Rows[i]["Id"]);
                dbEvent.WorldId = Convert.ToInt32(dt.Rows[i]["WorldId"]);
                dbEvent.EventName = dt.Rows[i]["EventName"].ToString();
                dbEvent.EventDescription = dt.Rows[i]["EventDesc"].ToString();
                dbEvent.EventResolved = Convert.ToBoolean(dt.Rows[i]["EventResolved"]);
                dbEvent.EventStart = DateOnly.FromDateTime(Convert.ToDateTime(dt.Rows[i]["EventStart"]));
                dbEvent.EventEnd = DateOnly.FromDateTime(Convert.ToDateTime(dt.Rows[i]["EventEnd"]));
                result.Add(dbEvent);
            }
            dbConn.ConnString.Close();

            return result;
        }

        public DbEvent GetEventById(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT * FROM Event WHERE EventId = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            DbEvent result = new DbEvent();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.EventId = Convert.ToInt32(dt.Rows[i]["Id"]);
                result.WorldId = Convert.ToInt32(dt.Rows[i]["WorldId"]);
                result.EventName = dt.Rows[i]["EventName"].ToString();
                result.EventDescription = dt.Rows[i]["EventDesc"].ToString();
                result.EventResolved = Convert.ToBoolean(dt.Rows[i]["EventResolved"]);
                result.EventStart = DateOnly.FromDateTime(Convert.ToDateTime(dt.Rows[i]["EventStart"]));
                result.EventEnd = DateOnly.FromDateTime(Convert.ToDateTime(dt.Rows[i]["EventEnd"]));
            }
            dbConn.ConnString.Close();

            return result;
        }

        public List<DbEvent> GetEventsByCharacter(int id)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "SELECT c.CharacterId, e.* FROM EventCharacter c INNER JOIN Event e ON c.EventId = e.Id WHERE c.CharacterId = @id";
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<DbEvent> result = new List<DbEvent>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DbEvent dbEvent = new DbEvent();
                dbEvent.EventId = Convert.ToInt32(dt.Rows[i]["Id"]);
                dbEvent.WorldId = Convert.ToInt32(dt.Rows[i]["WorldId"]);
                dbEvent.EventName = dt.Rows[i]["EventName"].ToString();
                dbEvent.EventDescription = dt.Rows[i]["EventDesc"].ToString();
                dbEvent.EventResolved = Convert.ToBoolean(dt.Rows[i]["EventResolved"]);
                dbEvent.EventStart = DateOnly.FromDateTime(Convert.ToDateTime(dt.Rows[i]["EventStart"]));
                dbEvent.EventEnd = DateOnly.FromDateTime(Convert.ToDateTime(dt.Rows[i]["EventEnd"]));
                result.Add(dbEvent);
            }
            dbConn.ConnString.Close();

            return result;
        }

        public void CreateEvent(DbEvent dbEvent)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "INSERT INTO Event (EventName, EventDesc, EventResolved, EventStart, EventEnd) VALUES (@eventName, @eventDesc, @eventResolved, @eventStart, @eventEndw)";
            command.Parameters.AddWithValue("@eventName", dbEvent.EventName);
            command.Parameters.AddWithValue("@eventDesc", dbEvent.EventDescription);
            command.Parameters.AddWithValue("@eventResolved", dbEvent.EventResolved);
            command.Parameters.AddWithValue("@eventStart", dbEvent.EventStart);
            command.Parameters.AddWithValue("@eventEnd", dbEvent.EventEnd);

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        public void UpdateEvent(DbEvent dbEvent)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "UPDATE Event SET EventName = @eventName, EventDesc = @eventDesc, EventResolved = @eventResolved, EventStart = @eventStart, EventEnd = @eventEnd  WHERE Id = @id";
            command.Parameters.AddWithValue("@eventName", dbEvent.EventName);
            command.Parameters.AddWithValue("@eventDesc", dbEvent.EventDescription);
            command.Parameters.AddWithValue("@eventResolved", dbEvent.EventResolved);
            command.Parameters.AddWithValue("@eventStart", dbEvent.EventStart);
            command.Parameters.AddWithValue("@eventEnd", dbEvent.EventEnd);

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }

        public void DeleteEvent(DbEvent dbEvent)
        {
            dbConn.ConnString.Open();
            SqlCommand command = dbConn.ConnString.CreateCommand();
            command.CommandText = "DELETE FROM EventCharacter WHERE EventId = @id";
            command.Parameters.AddWithValue("@id", dbEvent.EventId);

            command.ExecuteNonQuery();

            command.CommandText = "DELETE FROM Event WHERE Id = @id";

            command.ExecuteNonQuery();
            dbConn.ConnString.Close();
        }
        #endregion
    }
}
