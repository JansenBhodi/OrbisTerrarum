using OrbisTerrarum.Models;
using System.Data.SqlClient;

namespace OrbisTerrarum.Logic
{
    public class Database
    {
        private SqlConnection _conn = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=OrbisTerrarum;Integrated Security=True");

        public void CreateWorld(World world)
        {
            _conn.Open();
            SqlCommand command = _conn.CreateCommand();
            command.CommandText = "INSERT INTO World (WorldName) VALUES (@WorldName)";
            command.Parameters.AddWithValue("@WorldName", world.Name);

            command.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
