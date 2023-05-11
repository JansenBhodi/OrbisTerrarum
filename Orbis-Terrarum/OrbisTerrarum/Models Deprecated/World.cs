namespace OrbisTerrarum.Models
{
    public class World
    {

        public World(int id, string worldName, DateOnly year, int creatorId)
        {
            Id = id;
            WorldName = worldName;
            CurrentYear= year;
            CreatorId = creatorId;

        }

        public World(int id, string worldName, DateOnly year, string desc, int creatorId)
        {
            Id = id;
            WorldName = worldName;
            CurrentYear = year;
            CreatorId = creatorId;
            Description = desc;
        }

        public int Id { get; private set; }
        public string WorldName { get; private set; }
        public DateOnly CurrentYear { get; private set; }
        public string Description { get; private set; }
        public int CreatorId { get; private set; }


    }
}
