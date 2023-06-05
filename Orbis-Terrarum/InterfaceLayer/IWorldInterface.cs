using InterfaceLayerOrbis.DbClasses;

namespace InterfaceLayer
{
    public interface IWorldInterface
    {
        List<DbWorld> GetAllWorlds();

        DbWorld GetWorldById(int id);
        void CreateWorld(DbWorld world);
        void UpdateWorld(DbWorld world);
        void DeleteWorld(DbWorld world);
    }
}