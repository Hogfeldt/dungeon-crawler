using System;
using System.Collections.Generic;
using ServerApp.GameState;

namespace ServerApp.TurnExecute
{
    public class TurnExecutioner
    {
        private List<ICharacter> _characters;
        private GameStateClass _gameState;
        private IPosition _deadMobPosition = null;

        private IMovement _movement;

        public TurnExecutioner(GameStateClass gameState)
        {
            _movement = new Movement();
            this._gameState = gameState;
        }

        public GameStateClass Execute()
        {
            if (ValidatePlayerMove())
            {
                PopulateCharacters();
                SortCharactersBySpeedDescending();

                ExecuteCharacterMoves();
                RemoveDeadCharacters();

                if (_deadMobPosition != null)
                {
                    MovePlayerToDeadMobPosition();
                }

                if(_gameState.Player == null)
                {
                    // Player was killed, respawn
                    _gameState = GameStateFactory.GenerateNewGameState();
                }
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
        }

        private void RemoveDeadCharacters()
        {
            for (int i = _characters.Count - 1; i >= 0; i--)
            {
                if (!_characters[i].Alive)
                {
                    _gameState.Map.GetCurrentLayer().RemoveCharacterFromPosition(_characters[i].Position);
                    _characters.RemoveAt(i);
                }
            }
        }

        private void MovePlayerToDeadMobPosition()
        {
            _movement.MoveCharacter(_gameState.Player.Position, _deadMobPosition, _gameState.Map.GetCurrentLayer());
            //_gameState.Map.GetCurrentLayer().MoveCharacter(_gameState.Player.Position, _deadMobPosition);
        }

        private void ExecuteCharacterMove(ICharacter character)
        {
            var layer = _gameState.Map.GetCurrentLayer();
            var moveTo = PositionToMoveTo(character);

            //Character didn't wanna move, we are done.
            if (moveTo == null)
            {
                return;
            }


            //Attempt to move character, will return false if tile is not walkable or is already occupied
            if (!_movement.MoveCharacter(character.Position, moveTo, layer))
            {
                ICharacter characterOnTile = layer.GetCharacter(moveTo);
                //Moving didn't work, find out if failure was because it was occupied
                if (characterOnTile != null)
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

            // Handle interactive objects
            if (character.GetType() == typeof(Player) && layer.InteractiveObjects[moveTo.X, moveTo.Y] != null) {
                layer.InteractiveObjects[moveTo.X, moveTo.Y].interact(_gameState);
            }

            //Figure out if the player just moved onto next layer
            if (character.GetType() == typeof(Player) && layer.ExitPosition.X == moveTo.X && layer.ExitPosition.Y == moveTo.Y)
            {
                _gameState.Map.MovePlayerToNewLayer(_gameState.Map.CurrentLayerNumber + 1, true);
            }

            if (character.GetType() == typeof(Player) && layer.InitialPlayerPosition.X == moveTo.X && layer.InitialPlayerPosition.Y == moveTo.Y)
            {
                _gameState.Map.MovePlayerToNewLayer(_gameState.Map.CurrentLayerNumber - 1, false);
            }

            //Movement succeded, we are done.
        }


        private void PlayerFightHostileNPC(HostileNPC hostile)
        {
            //Punch the hostile NPC and save their position if they died.
            var player = _gameState.Map.GetPlayer();

            hostile.TakeDamage(player.Stats.Damage);
            if(!hostile.Alive)
            {
                //The monster died - Award gold and experience to player
                hostile.DropToCharacter(player);

                //Save the monster position so that we can move the player after cleaning the layer.
                _deadMobPosition = hostile.Position;
            }
        }

        private void HostileNPCFightPlayer(HostileNPC hostile)
        {
            //Punch the player and ????????????????? if they die.
            throw new NotImplementedException("HostileNPCFightPlayer isn't implemented yet");
        }

        public static Position PositionToMoveTo(ICharacter character)
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