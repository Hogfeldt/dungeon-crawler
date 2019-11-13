using System;
using System.Collections.Generic;
using ServerApp.Game;

namespace ServerApp.TurnExec
{
    public static class TurnExecutioner
    {
        public static GameState Execute(GameState gameState)
        {
            List<NPC> NPCs = gameState.GetNPCsOnLayer(gameState.Player.Layer);

            ILayer currentLayer = gameState.Map.GetLayer(gameState.Player.Layer);

            foreach (var character in NPCs)
            {
                character.GenerateMove();
            }

            List<Character> characters = new List<Character>();
            characters.Add(gameState.Player);
            characters.AddRange(NPCs);

            characters.Sort((c1, c2) => c2.Stats.Speed - c1.Stats.Speed);

            foreach (var character in characters)
            {
                Position moveTo = PositionToMoveTo(character);
                if (currentLayer.GetTile(moveTo).Walkable)
                {
                    NPC characterOnTile = currentLayer.GetNPC(moveTo);
                    if (currentLayer.GetNPC(moveTo) == null && gameState.Player.Position != moveTo)
                    {
                        if (character.GetType() == typeof(Player))
                        {
                            gameState = MovePlayer(gameState, moveTo);
                        }
                        else
                        {
                            gameState = MoveNPC(gameState, character as NPC, moveTo);
                        }
                    }
                    else
                    {
                        if (character.GetType() == typeof(Player))
                        {
                            gameState = PlayerFightNPC(gameState, moveTo);
                        } else if (character.GetType() == typeof(HostileNPC) && gameState.Player.Position == moveTo)
                        {
                            NPCFightPlayer(gameState, (HostileNPC) character);
                        }
                    }
                }
            }

            return gameState;
        }

        public static GameState PlayerFightNPC(GameState gameState, Position moveTo)
        {
            HostileNPC npc = (HostileNPC)gameState.Map.GetLayer(gameState.Player.Layer).GetNPC(moveTo);
            if (npc.TakeDamage(gameState.Player.Stats.Damage) == 0)
            {
                gameState.Player.AddGold(npc.DroppedGold);
                gameState.Map.GetLayer(gameState.Player.Layer).RemoveNPCFromPosition(moveTo);
                gameState.Player.Position = moveTo;
            }

            return gameState;
        }

        public static GameState NPCFightPlayer(GameState gameState, HostileNPC npc)
        {
            if (gameState.Player.TakeDamage(npc.Stats.Damage) == 0)
            {
                throw new NotImplementedException("The player died, woopsies");
            }

            return gameState;
        }

        public static GameState MovePlayer(GameState gameState, Position moveTo)
        {
            gameState.Player.Position = moveTo;
            return gameState;
        }
        public static GameState MoveNPC(GameState gameState, NPC npc, Position moveTo)
        {
            Position prevPosition = npc.Position;
            npc.Position = moveTo;

            gameState.Map.GetLayer(gameState.Player.Layer).RemoveNPCFromPosition(prevPosition);
            gameState.Map.GetLayer(gameState.Player.Layer).AddNPC(npc);

            return gameState;
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
                    return character.Position;
                default:
                    throw new NotImplementedException("Reached code path that should be unreachable - Character.Direction enum has changed");
            }
        }
    }
}