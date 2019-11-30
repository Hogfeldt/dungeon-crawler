namespace ServerApp.GameState
{
    public class Movement: IMovement
    {
        private bool checkIfValidMove(IPosition oldPosition, IPosition newPosition, ILayer layer)
        {
            bool characterDoesNotExsist = layer.GetCharacter(oldPosition) == null;
            if(characterDoesNotExsist) return false;
            bool newPositionIsNotValid = layer.PositionIsValid(newPosition);
            if(newPositionIsNotValid) return false;
            bool newPositionIsNotFree = layer.GetCharacter(newPosition) != null;
            if(newPositionIsNotFree) return false;
            bool newPositionIsNotWalkable = layer.GetTile(newPosition).Walkable == false;
            if(newPositionIsNotWalkable) return false;
            return true;
        }

        //Moves a character in the layer from oldPosition to newPosition
        //If move is invalid return false
        //If successful returns true
        public bool MoveCharacter(IPosition oldPosition, IPosition newPosition, ILayer layer)
        {
            if(checkIfValidMove(oldPosition, newPosition, layer)){
                ICharacter characterToMove = layer.GetCharacter(oldPosition);
                layer.RemoveCharacter(characterToMove);
                characterToMove.Position = newPosition;
                layer.AddCharacter(characterToMove);
                return true;
            }
            return false;
        }
    }
}
