using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ServerApp.GameState
{
    public class Layer: ILayer
    {
        public ITile[,] Tiles { private set; get; }
        public List<Character> Characters { private set; get; } = new List<Character>();

        public Layer(uint width, uint height)
        {
            Tiles = new ITile[width,height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    Tiles[x, y] = new Tile(null);
                }
            }
        }

        public void AddCharacter(Character character)
        {
            Characters.Add(character);
            Character replaced = Tiles[character.XPos, character.YPos].ReplaceCharacter(character);

            if (replaced != null)
            {
                Characters.Remove(replaced);
            }
        }

        public void RemoveCharacter(Character character)
        {
            if (Characters.Remove(character)) { 
                Tiles[character.XPos, character.YPos].RemoveCharacter();
            }

        }

        public ITile GetTile(uint x, uint y)
        {
            return Tiles[x, y];
        }
    }
}
