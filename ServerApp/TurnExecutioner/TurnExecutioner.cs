using System;
using System.Collections.Generic;
using ServerApp.Game;

namespace ServerApp.TurnExec
{
    public class TurnExecutioner
    {
        private List<Character> _characters;
        private GameState _gameState;

        public TurnExecutioner(GameState gameState)
        {
            this._gameState = gameState;
        }

        public GameState Execute()
        {
            if (ValidatePlayerMove())
            {
                PopulateCharacters();
                SortCharactersBySpeedDescending();

                ExecuteCharacterMoves();
            }

            return _gameState;
        }

        private bool ValidatePlayerMove()
        {
            var moveTo = PositionToMoveTo(_gameState.Player);
            if (_gameState.Map.GetCurrentLayer().GetTile(moveTo).Walkable)
            {
                return true;
            }

            return false;
        }

        private void PopulateCharacters()
        {
            _characters = _gameState.Map.GetCurrentLayer().CharactersAsList();
        }

        private void SortCharactersBySpeedDescending()
        {
            _characters.Sort((c1, c2) => c2.Stats.Speed - c1.Stats.Speed);
        }

        private void ExecuteCharacterMoves()
        {
            foreach (var character in _characters)
            {
                if (character.Alive)
                {
                    ExecuteCharacterMove(character);
                }
            }

            for (int i = _characters.Count - 1; i >= 0; i--)
            {
                if (!_characters[i].Alive)
                {
                    _gameState.Map.GetCurrentLayer().RemoveCharacterFromPosition(_characters[i].Position);
                    _characters.RemoveAt(i);
                }
            }
        }

        private void ExecuteCharacterMove(Character character)
        {
            var layer = _gameState.Map.GetCurrentLayer();
            var moveTo = PositionToMoveTo(character);

            //Character didn't wanna move, we are done.
            if (moveTo == null)
            {
                return;
            }

            //Attempt to move character, will return false if tile is not walkable or is already occupied
            if (!layer.MoveCharacter(character.Position, moveTo))
            {
                Character characterOnTile = layer.GetCharacter(moveTo);
                //Moving didn't work, find out if failure was because it was occupied
                if (layer.GetCharacter(moveTo) != null)
                {
                    //Couldn't move because tile was occupied, figure out if we punch character on tile.
                    if (character.GetType() == typeof(Player) && characterOnTile.GetType() == typeof(HostileNPC))
                    {
                        //character is Player and characterOnTile is HostileNPC, Player punches HostileNPC
                        PlayerFightHostileNPC((HostileNPC) characterOnTile);

                    } else if (character.GetType() == typeof(HostileNPC) && characterOnTile.GetType() == typeof(Player))
                    {
                        //character is HostileNPC and characterOnTile is Player, HostileNPC punches Player.
                        HostileNPCFightPlayer((HostileNPC) character);
                    }
                    //We don't punch our friends and thus do not move either, we are done.
                }
                //We couldn't move and there was no other character on tile, must mean we attempted to move into a wall
            }
            //Movement succeded, we are done.
        }


        private void PlayerFightHostileNPC(HostileNPC hostile)
        {
            //Punch the hostile NPC and move to their tile if we kill it.
            var player = _gameState.Player;
            //Deal damage to the monster and figure out if it died in one swoop.
            if(hostile.TakeDamage(player.Stats.Damage) == 0)
            {
                //Hostile died, save its position
                Position hostilePosition = new Position(hostile.Position);
                
                //Award gold to player
                hostile.DropGoldToChar(player);

                /*
                //Remove hostile from list of characters to execute actions for
                _characters.Remove(hostile);

                //Remove hostile from map
                _gameState.Map.GetCurrentLayer().RemoveCharacterFromPosition(hostile.Position);

                //Move character to hostilePosition, check if this fails, which it really shouldn't.

                if (!_gameState.Map.GetCurrentLayer().MoveCharacter(_gameState.Map.GetPlayer().Position, hostilePosition))
                {
                    throw new NotImplementedException(
                          "HostileNPC was killed and Player attempted to its location but failed");
                }
                */
            }
        }

        private void HostileNPCFightPlayer(HostileNPC hostile)
        {
            //Punch the player and ????????????????? if they die.
            throw new NotImplementedException("HostileNPCFightPlayer isn't implemented yet");
        }

        public static Position PositionToMoveTo(Character character)
        {
            switch (character.NextMove)
            {
                case Character.Direction.Up:
                    return new Position(character.Position.X, character.Position.Y - 1);
                case Character.Direction.Down: 
                    return new Position(character.Position.X, character.Position.Y + 1);
                case Character.Direction.Left:
                    return new Position(character.Position.X - 1, character.Position.Y);
                case Character.Direction.Right:
                    return new Position(character.Position.X + 1, character.Position.Y);
                case Character.Direction.None:
                    return null;
                default:
                    throw new NotImplementedException("Reached code path that should be unreachable - Character.Direction enum has changed");
            }
        }
    }
}