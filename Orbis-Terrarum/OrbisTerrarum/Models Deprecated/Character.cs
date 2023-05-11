namespace OrbisTerrarum.Models
{
    public class Character
    {
        public Character(int id, int worldId, string characterName, int characterAge, string characterDesc, int characterAlignment) 
        { 
            CharacterId = id;
            WorldId = worldId;
            CharacterName = characterName;
            CharacterAge = characterAge;
            CharacterDesc = characterDesc;
            CharacterAlignment = (Alignment)characterAlignment;
        }

        public int CharacterId { get; private set; }
        public int WorldId { get; private set; }
        public string CharacterName { get; private set; }
        public int CharacterAge { get; private set; }
        public string CharacterDesc { get; private set; }
        public Alignment CharacterAlignment { get; private set; }

    }
}
