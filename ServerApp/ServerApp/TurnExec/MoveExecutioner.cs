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

        public List<ICharacter> ExecuteMoves(Queue<ICharacter> turns, ILayer layer)
        {
            List<ICharacter> characters = new List<ICharacter>();
            foreach (var character in turns)
            {
                if (character.Alive)
                {
                    IPosition targetPosition;
                    switch (character.NextMove)
                    {
                        case Character.Direction.Up:
                            targetPosition = new Position(character.Position.X, character.Position.Y - 1);
                            break;
                        case Character.Direction.Down:
                            targetPosition = new Position(character.Position.X, character.Position.Y + 1);
                            break;
                        case Character.Direction.Left:
                            targetPosition = new Position(character.Position.X - 1, character.Position.Y);
                            break;
                        case Character.Direction.Right:
                            targetPosition = new Position(character.Position.X + 1, character.Position.Y);
                            break;
                        case Character.Direction.None:
                            targetPosition = null;
                            break;
                        default:
                            throw new NotImplementedException("Reached code path that should be unreachable - Character.Direction enum has changed");
                    }
                    if (targetPosition != null)
                    {
                        MoveCharacter(character, targetPosition, layer);
                    }
                    characters.Add(character);
                }
            }
            List<ICharacter> survivors = new List<ICharacter>();
            foreach (var character in characters)
            {
                if (character.Alive)
                {
                    survivors.Add(character);
                }
            }
            return survivors;
        }

        private void MoveCharacter(ICharacter character, IPosition targetPosition, ILayer layer)
        {
            //Attempt to move character, will return false if tile is not walkable or is already occupied
            if (!_movement.MoveCharacter(character.Position, targetPosition, layer))
            {
                //Moving didn't work, find out if failure was because it was occupied
                ICharacter characterOnTile = layer.GetCharacter(targetPosition);
                if (characterOnTile != null)
                {
                    _combatHandler.Fight(character, characterOnTile);
                    // TODO move or what??
                }
            }
        }
    }
}
