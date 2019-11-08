using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ServerApp.GameState
{
    public class Layer: ILayer
    {
        public ITile[,] tiles { private set; get; }
        public List<ICharacter> Characters { private set; get; } = new List<ICharacter>();

        public Layer(uint width, uint height)
        {
            tiles = new ITile[width,height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile();
                }
            }
        }

        public void AddCharacter(ICharacter character)
        {
            Characters.Add(character);
        }

        public void RemoveCharacter(ICharacter character)
        {
            Characters.Remove(character);
        }

        public ITile GetTile(uint x, uint y)
        {
            return tiles[x, y];
        }
    }
}
