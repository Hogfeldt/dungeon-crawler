using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class MoveExecutionerTest
    {
        private IMoveExecutioner _uut;
        private ICombatHandler _combatHandler;
        private ITile[, ] _tiles;

        [SetUp]
        public void Setup()
        {
            _combatHandler = new CombatHandler();
            _uut = new MoveExecutioner(_combatHandler);

            _tiles = new ITile[10, 10];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    _tiles[x, y] = new Tile(true);
                }
            }
        }

        [Test]
        public void MoveExecutioner_PlayerMovesDown_PlayerHasMoved()
        {
            var turns = new Queue<ICharacter>();
            var characters = new Character[10, 10];

            var npc1 = new HostileNPC(new Position(1, 1), new Stats(), new StandStillMovementStrategy(), "bad boi 1");
            var npc2 = new HostileNPC(new Position(2, 2), new Stats(), new StandStillMovementStrategy(), "bad boi 2");
            var player = new Player(new Position(5, 5), new Stats(), "player boi", 0, 0);

            player.SetNextMove(Character.Direction.Down);
            turns.Enqueue(npc1);
            turns.Enqueue(npc2);
            turns.Enqueue(player);

            characters[npc1.Position.X, npc1.Position.Y] = npc1;
            characters[npc2.Position.X, npc2.Position.Y] = npc2;
            characters[player.Position.X, player.Position.Y] = player;

            var layer = new Layer(
                _tiles, 
                characters, 
                new Position(0, 0), new Position(9, 9), 
                new IInteractiveObject[10, 10]);

            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(turns, layer);


            // Player moves down, should increment Y position
            Assert.AreEqual(5, player.Position.X);
            Assert.AreEqual(6, player.Position.Y);
        }
    }
}
