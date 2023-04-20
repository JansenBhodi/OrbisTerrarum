namespace OrbisTerrarum.Models
{
    public class World
    {

        public World(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }


    }
}
