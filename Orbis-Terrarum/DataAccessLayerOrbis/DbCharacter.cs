namespace DataAccessLayerOrbis
{
    public class DbCharacter
    {
        public DbCharacter(int id, int worldId, string characterName, int characterAge, string characterDesc, int characterAlignment)
        {
            Id = id;
            WorldId = worldId;
            CharacterName = characterName;
            CharacterAge = characterAge;
            CharacterDesc = characterDesc;
            CharacterAlignment = characterAlignment;
        }

        public int Id { get; private set; }
        public int WorldId { get; private set; }
        public string CharacterName { get; private set; }
        public int CharacterAge { get; private set; }
        public string CharacterDesc { get; private set; }
        public int CharacterAlignment { get; private set; }

    }
}
