using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class MoveExecutioner : IMoveExecutioner
    {
        private readonly ICombatHandler _combatHandler;
        private readonly IMovement _movement;
        public MoveExecutioner(ICombatHandler combatHandler, IMovement movement)
        {
            _movement = movement;
            _combatHandler = combatHandler;
        }

        public void ExecuteMoves(Queue<ICharacter> turns, ILayer layer)
        {
            foreach (var character in turns)
            {
                if (character.Alive)
                {
                    IPosition targetPosition;
                    switch (character.NextMove)
                    {
                        case Direction.Up:
                            targetPosition = new Position(character.Position.X, character.Position.Y - 1);
                            break;
                        case Direction.Down:
                            targetPosition = new Position(character.Position.X, character.Position.Y + 1);
                            break;
                        case Direction.Left:
                            targetPosition = new Position(character.Position.X - 1, character.Position.Y);
                            break;
                        case Direction.Right:
                            targetPosition = new Position(character.Position.X + 1, character.Position.Y);
                            break;
                        case Direction.None:
                            targetPosition = null;
                            break;
                        default:
                            throw new NotImplementedException("Reached code path that should be unreachable - Character.Direction enum has changed");
                    }
                    if (targetPosition != null)
                    {
                        MoveCharacter(character, targetPosition, layer);
                    }
                }
            }
        }

        private void MoveCharacter(ICharacter movingCharacter, IPosition targetPosition, ILayer layer)
        {
            //Attempt to move character, will return false if tile is not walkable or is already occupied
            if (!_movement.MoveCharacter(movingCharacter.Position, targetPosition, layer))
            {
                //Moving didn't work, find out if failure was because it was occupied
                ICharacter characterOnTile = layer.GetCharacter(targetPosition);
                if (characterOnTile != null)
                {
                    _combatHandler.Fight(movingCharacter, characterOnTile, layer);
                    // Try to move again will succed if opponent is dead
                    _movement.MoveCharacter(movingCharacter.Position, targetPosition, layer);
                }
            }
        }
    }
}
