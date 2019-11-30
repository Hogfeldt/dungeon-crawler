using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public abstract class Layer : ILayer
    {
        protected Layer() {}

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
        public bool PositionIsValid(IPosition position)
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
            if (PositionIsValid(character.Position))
            {
                Characters[character.Position.X, character.Position.Y] = character;
            }
        }
        

        public void RemoveCharacter(ICharacter character)
        {
            if (PositionIsValid(character.Position))
            {
                Characters[character.Position.X, character.Position.Y] = null;
            }
        }
        

        public ICharacter GetCharacter(IPosition position)
        {
            if (PositionIsValid(position))
            {
                return Characters[position.X, position.Y];
            }
            return null;
        }
        

        public ITile GetTile(IPosition position)
        {
            if (!PositionIsValid(position))
            {
                bool isWalkable = false;
                return new Tile(isWalkable);
            }
            return Tiles[position.X, position.Y];
        }
    }
}
