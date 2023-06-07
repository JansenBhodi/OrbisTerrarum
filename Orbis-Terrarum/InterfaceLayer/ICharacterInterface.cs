using InterfaceLayerOrbis.DbClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayerOrbis
{
    public interface ICharacterInterface
    {
        List<DbCharacter> GetCharactersByWorld(int id);
        void UpdateCharacter(DbCharacter character);
        DbCharacter GetCharacterById(int id);
        void CreateCharacter(DbCharacter character);
        List<DbCharacter> GetCharactersByEvent(int id);
        void DeleteCharacter(DbCharacter character);
    }
}
