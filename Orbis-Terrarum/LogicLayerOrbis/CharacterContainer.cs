using FactoryLayerOrbis;
using InterfaceLayerOrbis;
using InterfaceLayerOrbis.DbClasses;
using LogicLayerOrbis.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace LogicLayerOrbis
{
    public class CharacterContainer
    {
        ICharacterInterface characterInterface = Factory.GetCharacterInterface();

        public List<Character> GetCharactersByWorld(int id)
        {
            List<Character> list = new List<Character>();
            List<DbCharacter> db = new List<DbCharacter>();
            try
            {
                db = characterInterface.GetCharactersByWorld(id);
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                foreach (DbCharacter c in db)
                {
                    Character character = new Character(c.Id, c.WorldId, c.CharacterName, c.CharacterAge, c.CharacterDesc, c.CharacterAlignment);
                    list.Add(character);
                }
            }
            catch (Exception)
            {

                throw new CreateItemListException("Failed to add a database entry to the model. Check database entry.");
            }

            return list;
        }

        public List<Character> GetCharactersByEvent(int id)
        {
            List<Character> list = new List<Character>();
            List<DbCharacter> db = new List<DbCharacter>();

            try
            {
                db = characterInterface.GetCharactersByEvent(id);
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                foreach (DbCharacter c in db)
                {
                    Character character = new Character(c.Id, c.WorldId, c.CharacterName, c.CharacterAge, c.CharacterDesc, c.CharacterAlignment);
                    list.Add(character);
                }
            }
            catch (Exception)
            {

                throw new CreateItemListException("Failed to add a database entry to the model. Check database entry.");
            }

            return list;
        }

        public Character GetCharacterById(int id)
        {
            DbCharacter db = new DbCharacter();

            try
            {
                db = characterInterface.GetCharacterById(id);
            }
            catch (Exception)
            {

                throw;
            }

            Character result = new Character(db.Id, db.WorldId, db.CharacterName, db.CharacterAge, db.CharacterDesc, db.CharacterAlignment);

            return result;
        }

        public void CreateCharacter(Character input)
        {
            DbCharacter db = new DbCharacter();

            try
            {
                db.WorldId = input.WorldId;
                db.CharacterName = input.CharacterName;
                db.CharacterDesc = input.CharacterDesc;
                db.CharacterAge = input.CharacterAge;
                db.CharacterAlignment = input.CharacterAlignment;
            }
            catch (Exception)
            {

                throw new CreateInputFromModelException("Couldn't convert model to database class, check conversion.");
            }

            try
            {
                characterInterface.CreateCharacter(db);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateCharacter(Character update)
        {
            DbCharacter db = new DbCharacter();

            db.Id = update.Id;
            db.CharacterName = update.CharacterName;
            db.CharacterDesc = update.CharacterDesc;
            db.CharacterAge = update.CharacterAge;
            db.CharacterAlignment = update.CharacterAlignment;

            try
            {
                characterInterface.UpdateCharacter(db);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCharacter(int target)
        {
            DbCharacter db = new DbCharacter();

            db.Id = target;

            try
            {
                characterInterface.DeleteCharacter(db);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
