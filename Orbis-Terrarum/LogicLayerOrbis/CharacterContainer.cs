using FactoryLayerOrbis;
using InterfaceLayerOrbis;
using InterfaceLayerOrbis.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerOrbis
{
    public class CharacterContainer
    {
        ICharacterInterface characterInterface = Factory.GetCharacterInterface();

        public List<Character> GetCharactersByWorld(int id)
        {
            List<Character> list = new List<Character>();

            List<DbCharacter> db = characterInterface.GetCharactersByWorld(id);
            foreach (DbCharacter c in db) 
            {
                Character character = new Character(c.Id, c.WorldId, c.CharacterName, c.CharacterAge, c.CharacterDesc, c.CharacterAlignment);
                list.Add(character);
            }

            return list;
        }
    }
}
