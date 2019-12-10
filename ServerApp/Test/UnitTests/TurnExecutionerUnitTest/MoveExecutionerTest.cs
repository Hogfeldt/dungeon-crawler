﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class MoveExecutionerTest
    {
        private IMoveExecutioner _uut;
        private IMovement _movement;
        private ICombatHandler _combatHandler;
        private ITile[,] _tiles;
        private Queue<ICharacter> _turns;

        private IInteractiveObject[,] _interactiveObjects;
        private IGameState _gameState;

        private ICharacter _player;
        private ICharacter _npc1;
        private ICharacter _npc2;
        private ILayer _layer;

        class DumbLayer : Layer
        {
            public DumbLayer(ITile[,] tiles, ICharacter[,] characters, IInteractiveObject[,] interactiveObjects)
                : base(tiles, characters, interactiveObjects)
            { }

            public override IPosition getEnteringPositionOrNull()
            {
                throw new NotImplementedException();
            }

            public override IPosition getExitingPositionOrNull()
            {
                throw new NotImplementedException();
            }
        }


        [SetUp]
        public void Setup()
        {
            //_combatHandler = new CombatHandler();
            _combatHandler = Substitute.For<ICombatHandler>();
            _movement = Substitute.For<IMovement>();

            _uut = new MoveExecutioner(_combatHandler, _movement);

            _tiles = new ITile[10, 10];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    _tiles[x, y] = new Tile(true);
                }
            }

            _turns = new Queue<ICharacter>();
            var characters = new ICharacter[10, 10];

            _npc1 = new HostileNPC(new Position(1, 1), new Stats(), new StandStillMovementStrategy(), "bad boi 1");
            _npc2 = new HostileNPC(new Position(2, 2), new Stats(), new StandStillMovementStrategy(), "bad boi 2");
            _player = new Player(new Position(5, 5), new Stats(100, 10, 1), "player boi", 0);

            _turns.Enqueue(_npc1);
            _turns.Enqueue(_npc2);
            _turns.Enqueue(_player);

            characters[_npc1.Position.X, _npc1.Position.Y] = _npc1;
            characters[_npc2.Position.X, _npc2.Position.Y] = _npc2;
            characters[_player.Position.X, _player.Position.Y] = _player;

            _interactiveObjects = new IInteractiveObject[10, 10];
            _layer = new DumbLayer(_tiles, characters, _interactiveObjects);

            _gameState = Substitute.For<IGameState>();
            /*
            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));
            */


        }
        
        [Test]
        public void MoveExecutioner_ExecuteMove_PlayerHasMoved()
        {
            //_player.NextMove(Direction.Down);

            //_player.SetNextMove(Character.Direction.Down);
            //List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // Player moves down, should increment Y position

            //_player.NextMove(Direction.Down);
            _gameState.Player.SetNextMove(Direction.Down);

            _uut.ExecuteMoves(_turns, _layer);

            Assert.AreEqual(5, _player.Position.X);
            Assert.AreEqual(5, _player.Position.Y);
        }

        /*
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
            _npc2.Stats = new Stats(100, 0, 0);

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
            _npc2.Stats = new Stats(100, 0, 0);
            _player.SetNextMove(Character.Direction.Up);

            List<ICharacter> charactersAfterTurn = _uut.ExecuteMoves(_turns, _layer);

            // player has not moved
            Assert.AreEqual(2, _player.Position.X);
            Assert.AreEqual(3, _player.Position.Y);
        }
        */
    }
}
