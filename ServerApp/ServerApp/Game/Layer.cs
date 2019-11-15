using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ServerApp.Game
{
    public class Layer: ILayer
    {
        public int Height { private set; get; }
        public int Width { private set; get; }
        public ITile[,] Tiles { private set; get; }
        public Character[,] Characters { private set; get; }

        public Position InitialPlayerPosition { private set; get; }

        [JsonConstructor]
        public Layer(ITile[,] tiles, Character[,] characters, Position initialPlayerPosition)
        {
            Tiles = tiles;
            Characters = characters;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            InitialPlayerPosition = initialPlayerPosition;
        }

        //Validates a position in the layer, returns true if position is within bounds of layer.
        private bool PositionIsValid(Position position)
        {
            if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height) return false;
            return true;
        }

        //Moves a character in the layer from oldPosition to newPosition
        //If either position is invalid or newPosition is already occupied returns false
        //If successful returns true
        public bool MoveCharacter(Position oldPosition, Position newPosition)
        {
            if(!PositionIsValid(oldPosition) || !PositionIsValid(newPosition))
            {
                return false;
            }

            if(GetCharacter(newPosition) != null || !GetTile(newPosition).Walkable)
            {
                return false;
            }

            Character toMove = GetCharacter(oldPosition);
            toMove.Position = newPosition;
            AddCharacter(toMove);
            RemoveCharacterFromPosition(oldPosition);

            return true;
        }

        public void AddCharacter(Character character)
        {
            if (!PositionIsValid(character.Position))
            {
                return;
            }

            Characters[character.Position.X, character.Position.Y] = character;
        }

        public void RemoveCharacterFromPosition(Position position)
        {
            if (!PositionIsValid(position))
            {
                return;
            }

            Characters[position.X, position.Y] = null;
        }

        public Character GetCharacter(Position position)
        {
            if (!PositionIsValid(position))
            {
                return null;
            }
            return Characters[position.X, position.Y];
        }

        public Character GetCharacterFromPositionWithOffset(Position position, int xOff, int yOff)
        {
            Position offsetPosition = new Position(position, xOff, yOff);

            return GetCharacter(offsetPosition);
        }

        public ITile GetTile(Position position)
        {
            if (!PositionIsValid(position))
            {
                return new Tile(false);
            }
            return Tiles[position.X, position.Y];
        }

        public ITile GetTileWithOffset(Position position, int xOff, int yOff)
        {
            Position offSetPosition = new Position(position, xOff, yOff);

            return GetTile(offSetPosition);
        }

        public List<Character> CharactersAsList()
        {
            List<Character> characterList = new List<Character>();

            foreach (var character in Characters)
            {
                if (character != null)
                {
                    characterList.Add(character);
                }
            }

            return characterList;
        }
    }
}
