namespace LogicLayerOrbis
{
    public class World
    {
        public int Id { get; private set; }
        public string WorldName { get; private set; }
        public DateOnly WorldCurrentYear { get; private set; }
        public string WorldDesc { get; private set; }
        public int CreatorId { get; private set; }


        public World(int id, string worldName, DateOnly year, int creatorId)
        {
            Id = id;
            WorldName = worldName;
            WorldCurrentYear = year;
            CreatorId = creatorId;

        }
        public World(int id, string worldName, DateOnly year, string desc, int creatorId)
        {
            Id = id;
            WorldName = worldName;
            WorldCurrentYear = year;
            CreatorId = creatorId;
            WorldDesc = desc;
        }
        //Update this world function

        public void UpdateWorld(World newWorld)
        {
            WorldName = newWorld.WorldName;
            WorldCurrentYear = newWorld.WorldCurrentYear;
            WorldDesc = newWorld.WorldDesc;
        }
    }
}