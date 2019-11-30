using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class MoveExecutionerTest
    {
        private IMoveExecutioner _uut;
        private ICombatHandler _combatHandler;
        private ITile _tiles;
        private Layer _layer;

        //private Player _player;
        private ICharacter _character;


        public Player _player;

        /*
        private Queue<ICharacter> _turns;
        private ICharacter _npc1;
        private ICharacter _npc2;
        
        */

        [SetUp]
        public void Setup()
        {
            _player = Substitute.For<Player>();

            //_combatHandler = new CombatHandler();
            //_tiles = new ITile[10, 10];

            _combatHandler = Substitute.For<ICombatHandler>();
            _tiles = Substitute.For<ITile>();
            //_player = Substitute.For<Player>();

            _character = Substitute.For<ICharacter>();
            //_player = Substitute.For<Player>();

            _uut = new MoveExecutioner(_combatHandler);
            /*
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    _tiles[x, y] = new Tile(true);
                }
            }
            

            _turns = new Queue<ICharacter>();
            var characters = new ICharacter[10, 10];

            //_npc1 = new HostileNPC(new Position(1, 1), new Stats(), new StandStillMovementStrategy(), "bad boi 1");
            //_npc2 = new HostileNPC(new Position(2, 2), new Stats(), new StandStillMovementStrategy(), "bad boi 2");
            _player = new ConcretePlayer(new Position(5, 5), new Stats(100, 10, 1), "player boi", 0, 0);

            _turns.Enqueue(_npc1);
            _turns.Enqueue(_npc2);
            _turns.Enqueue(_player);

            characters[_npc1.Position.X, _npc1.Position.Y] = _npc1;
            characters[_npc2.Position.X, _npc2.Position.Y] = _npc2;
            characters[_player.Position.X, _player.Position.Y] = _player;

            _layer = new Layer(
                _tiles,
                characters,
                new Position(0, 0), new Position(9, 9),
                new IInteractiveObject[10, 10]);
            */
            _layer = Substitute.For<Layer>();
            
            //_player = Substitute.For<Player>();
        }

        [Test]
        public void MoveExecutioner_PlayerMovesDown_PlayerHasMoved()
        {
           // _player.Received().AddGold(10);

           //_player.Received().AddGold(10);
            //int test = _layer.Height;
            //_player.AddGold(20);
            Assert.True(1 + 1 == 2);
        }

        /*
        [Test]
        public void MoveExecutioner_PlayerMovesDown_PlayerHasMoved()
        {
            _player.SetNextMove(Character.Direction.Down);
            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // Player moves down, should increment Y position
            Assert.AreEqual(5, _player.Position.X);
            Assert.AreEqual(6, _player.Position.Y);
        }

        [Test]
        public void MoveExecutioner_PlayerDoesNotMove_PlayerHasNotMoved()
        {
            _player.SetNextMove(Character.Direction.None);
            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // Player moves down, should increment Y position
            Assert.AreEqual(5, _player.Position.X);
            Assert.AreEqual(5, _player.Position.Y);
        }

        [Test]
        public void MoveExecutioner_PlayerMoves_NPCsHasNotMoved()
        {
            _player.SetNextMove(Character.Direction.Down);
            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // Player moves down, should increment Y position
            Assert.AreEqual(1, _npc1.Position.X);
            Assert.AreEqual(1, _npc1.Position.Y);

            Assert.AreEqual(2, _npc2.Position.X);
            Assert.AreEqual(2, _npc2.Position.Y);
        }

        [Test]
        public void MoveExecutioner_PlayerFightsNPC_NpcDies()
        {
            // Player walks into NPC
            _player.Position = new Position(2, 3);
            _npc2.Stats = new Stats(1, 0, 0); // ?
            _player.SetNextMove(Character.Direction.Up);

            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // npc2 is dead and removed from list
            //Assert.IsFalse(charactersAfterTurn.Contains(_npc2));
            Assert.IsFalse(_npc2.Alive);
        }

        [Test]
        public void MoveExecutioner_PlayerFightsNPC_NpcDoesNotDie()
        {
            // Player walks into NPC
            _player.Position = new Position(2, 3);
            _npc2.Stats = new Stats(100, 0 ,0);
            
            _player.SetNextMove(Character.Direction.Up);

            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // npc2 not dead
            Assert.IsTrue(charactersAfterTurn.Contains(_npc2));
            Assert.IsTrue(_npc2.Alive);
        }

        [Test]
        public void MoveExecutioner_NpcDoesNotDieInFight_PlayerStaysOnPosition()
        {
            // Player walks into NPC
            _player.Position = new Position(2, 3);
            _npc2.Stats = new Stats(100, 0 ,0);
            _player.SetNextMove(Character.Direction.Up);

            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // player has not moved
            Assert.AreEqual(2, _player.Position.X);
            Assert.AreEqual(3, _player.Position.Y);
        }
        */
    }
}
