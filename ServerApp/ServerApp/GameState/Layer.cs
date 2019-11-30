using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public abstract class Layer
    {
        public int Height { protected set; get; }
        public int Width { protected set; get; }
        public ITile[,] Tiles { protected set; get; }
        public ICharacter[,] Characters { set; get; }
        public IInteractiveObject[,] InteractiveObjects {protected set; get;}
        protected IPosition EnteringPosition;
        protected IPosition ExitingPosition;

        /*[JsonConstructor]
        protected Layer(ITile[,] tiles, ICharacter[,] characters, IPosition initialPlayerPosition, IPosition EnteringPosition, IPosition ExitingPosition, IInteractiveObject[,] interactiveObjects)
        {
            Tiles = tiles;
            Characters = characters;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            InteractiveObjects = interactiveObjects;
            this.EnteringPosition = EnteringPosition;
            this.ExitingPosition = ExitingPosition;
        }*/

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
            InteractiveObjects[EnteringPosition.X, EnteringPosition.Y] = new DecendingStair();
        }

        //Moves a character in the layer from oldPosition to newPosition
        //If either position is invalid or newPosition is already occupied returns false
        //If successful returns true
        public bool MoveCharacter(IPosition oldPosition, IPosition newPosition)
        {
            if(!PositionIsValid(oldPosition) || !PositionIsValid(newPosition))
            {
                return false;
            }

            if(GetCharacter(newPosition) != null || !GetTile(newPosition).Walkable)
            {
                return false;
            }

            ICharacter toMove = GetCharacter(oldPosition);
            toMove.Position = newPosition;
            AddCharacter(toMove);
            RemoveCharacterFromPosition(oldPosition);

            return true;
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
