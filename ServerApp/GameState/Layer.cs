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
        public Character[,] NPCs { private set; get; }

        public Layer(uint width, uint height)
        {
            Tiles = new ITile[width,height];
            NPCs = new Character[width,height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    Tiles[x, y] = new Tile(true);
                    NPCs[x, y] = null;
                }
            }
        }

        public void AddCharacter(Character character) { }
        public void RemoveCharacter(Character character) { }

        /*
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
        */

        public ITile GetTile(uint x, uint y)
        {
            return Tiles[x, y];
        }
    }
}
