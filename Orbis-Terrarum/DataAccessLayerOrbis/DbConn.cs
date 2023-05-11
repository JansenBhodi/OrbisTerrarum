using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerOrbis
{
    public class DbConn
    {
        public SqlConnection ConnString = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=OrbisTerrarum;Integrated Security=True");
    }
}
