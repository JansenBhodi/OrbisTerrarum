using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis
{
    public class Character
    {
        public int Id { get; set; }
        public int WorldId { get; set; }
        public string CharacterName { get; set; }
        public int CharacterAge { get; set; }
        public string CharacterDesc { get; set; }
        public int CharacterAlignment { get; set; }

        public Character(int id, int worldId, string characterName, int characterAge, string characterDesc, int characterAlignment)
        {
            Id = id;
            WorldId = worldId;
            CharacterName = characterName;
            CharacterAge = characterAge;
            CharacterDesc = characterDesc;
            CharacterAlignment = characterAlignment;
        }

        public void UpdateCharacter(Character update)
        {
            CharacterName = update.CharacterName;
            CharacterAge = update.CharacterAge;
            CharacterDesc = update.CharacterDesc;
            CharacterAlignment = update.CharacterAlignment;
        }
    }
}
