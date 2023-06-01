namespace InterfaceLayerOrbis.DbClasses
{
    public class DbCharacter
    {

        public int Id { get;  set; }
        public int WorldId { get;  set; }
        public string CharacterName { get;  set; }
        public int CharacterAge { get;  set; }
        public string CharacterDesc { get;  set; }
        public int CharacterAlignment { get;  set; }

    }
}
