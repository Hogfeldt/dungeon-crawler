using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public abstract class Layer
    {
        protected Layer()
        {

        }

        public int Height { protected set; get; }
        public int Width { protected set; get; }
        public ITile[,] Tiles { protected set; get; }
        public ICharacter[,] Characters { set; get; }
        public IInteractiveObject[,] InteractiveObjects {protected set; get;}
        public IPosition EnteringPosition;
        public IPosition ExitingPosition;

        protected Layer(ITile[,] tiles, ICharacter[,] characters, IInteractiveObject[,] interactiveObjects)
        {
            Tiles = tiles;
            Characters = characters;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            InteractiveObjects = interactiveObjects;
        }

        public abstract IPosition getExitingPositionOrNull();

        public abstract IPosition getEnteringPositionOrNull();

        //Validates a position in the layer, returns true if position is within bounds of layer.
        private bool PositionIsValid(IPosition position)
        {
            if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height) return false;
            return true;
        }

        protected void initializeAccendigStair() 
        {
            InteractiveObjects[EnteringPosition.X, EnteringPosition.Y] = new AccendingStair();
        }

        protected void initializeDecendingStair() 
        {
            InteractiveObjects[ExitingPosition.X, ExitingPosition.Y] = new DecendingStair();
        }

        public void AddCharacter(ICharacter character)
        {
            if (!PositionIsValid(character.Position))
            {
                return;
            }

            Characters[character.Position.X, character.Position.Y] = character;
        }
        

        public void RemoveCharacterFromPosition(IPosition position)
        {
            if (!PositionIsValid(position))
            {
                return;
            }

            Characters[position.X, position.Y] = null;
        }
        

        public ICharacter GetCharacter(IPosition position)
        {
            if (!PositionIsValid(position))
            {
                return null;
            }
            return Characters[position.X, position.Y];
        }
        

        public ICharacter GetCharacterFromPositionWithOffset(IPosition position, int xOff, int yOff)
        {
            IPosition offsetPosition = new Position(position, xOff, yOff);

            return GetCharacter(offsetPosition);
        }
        

        public ITile GetTile(IPosition position)
        {
            if (!PositionIsValid(position))
            {
                return new Tile(false);
            }
            return Tiles[position.X, position.Y];
        }

        public ITile GetTileWithOffset(IPosition position, int xOff, int yOff)
        {
            IPosition offSetPosition = new Position(position, xOff, yOff);

            return GetTile(offSetPosition);
        }

        public List<ICharacter> CharactersAsList()
        {
            List<ICharacter> characterList = new List<ICharacter>();

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
