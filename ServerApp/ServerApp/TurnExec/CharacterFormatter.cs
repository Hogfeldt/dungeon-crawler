using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class CharacterFormatter : ICharacterFormatter
    {
        public List<ICharacter> ToList(ICharacter[,] characterGrid)
        {
            List<ICharacter> characters = new List<ICharacter>();
            foreach (var character in characterGrid)
            {
                if (character != null)
                {
                    characters.Add(character);
                }
            }

            return characters;
        }

        public ICharacter[,] ToGrid(List<ICharacter> characterList)
        {
            ICharacter[, ] characterGrid = new ICharacter[10, 10];
            foreach (var character in characterList)
            {
                characterGrid[character.Position.X, character.Position.Y] = character;
            }

            return characterGrid;
        }
    }
}
