using System.Data.Entity;

namespace OrbisTerrarum.Models
{
    public class WorldContext : DbContext
    {
        public WorldContext() : base()
        {

        }

        public DbSet<World> Worlds { get; set; }
    }
}
