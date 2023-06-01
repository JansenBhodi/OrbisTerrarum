using InterfaceLayerOrbis.DbClasses;

namespace InterfaceLayer
{
    public interface IWorldInterface
    {
        List<DbWorld> GetAllWorlds();

        public DbWorld GetWorldById(int id);
        void CreateWorld(DbWorld world);
    }
}