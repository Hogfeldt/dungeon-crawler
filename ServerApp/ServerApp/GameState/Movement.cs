﻿using System.Collections.Generic;
using Newtonsoft.Json;


namespace ServerApp.GameState
{
    public class Movement: IMovement
    {
        //Validates a position in the layer, returns true if position is within bounds of layer.
        private bool PositionIsValid(IPosition position, Layer layer)
        {
            if (position.X < 0 || position.X >= layer.Width || position.Y < 0 || position.Y >= layer.Height) return false;
            return true;
        }

        //Moves a character in the layer from oldPosition to newPosition
        //If either position is invalid or newPosition is already occupied returns false
        //If successful returns true
        public bool MoveCharacter(IPosition oldPosition, IPosition newPosition, Layer layer)
        {
            if (!PositionIsValid(oldPosition, layer) || !PositionIsValid(newPosition, layer))
            {
                return false;
            }

            if (layer.GetCharacter(newPosition) != null || !layer.GetTile(newPosition).Walkable)
            {
                return false;
            }

            ICharacter toMove = layer.GetCharacter(oldPosition);
            toMove.Position = newPosition;
            layer.AddCharacter(toMove);
            layer.RemoveCharacterFromPosition(oldPosition);

            return true;
        }
    }
}
