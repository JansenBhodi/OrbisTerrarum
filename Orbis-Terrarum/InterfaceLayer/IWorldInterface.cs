

namespace InterfaceLayer
{
    public interface IWorldInterface
    {
        List<DbWorld> GetAllWorlds();

        void CreateWorld(DbWorld world);
    }
}