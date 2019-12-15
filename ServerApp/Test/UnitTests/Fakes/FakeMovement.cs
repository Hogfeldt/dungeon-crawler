using System;
using System.Collections.Generic;
using System.Text;
using ServerApp.GameState;

namespace Test.UnitTests.Fakes
{
    class FakeMovement : IMovement
    {
        // All moves are valid
        private bool checkIfValidMove(IPosition currentPosition, IPosition newPosition, ILayer layer)
        {
            return true;
        }

        //Moves a character in the layer from oldPosition to newPosition
        //If move is invalid return false
        //If successful returns true
        public bool MoveCharacter(IPosition currentPosition, IPosition newPosition, ILayer layer)
        {
            if (checkIfValidMove(currentPosition, newPosition, layer))
            {
                ICharacter characterToMove = layer.GetCharacter(currentPosition);
                layer.RemoveCharacter(characterToMove);
                characterToMove.Position = newPosition;
                layer.AddCharacter(characterToMove);
                return true;
            }
            return false;
        }
    }
}

