using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;
using Test.UnitTests.Fakes;

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

        [SetUp]
        public void Setup()
        {
            _combatHandler = Substitute.For<ICombatHandler>();
            //_movement = Substitute.For<IMovement>();

            //_movement = new Movement();
            _uut = new MoveExecutioner(_combatHandler, new FakeMovement());

            //_movement.MoveCharacter().Returns(true);

            _turns = new Queue<ICharacter>();
            
            _gameState = new GameStateClass(
                new Map(
                    new FakeLayer(), 
                    1,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));
            
        }

        [Test]
        public void MoveExecutioner_ExecuteMove_PlayerMovesUp()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.Up);

            _turns.Enqueue(_gameState.Player);

            // Act
            _uut.ExecuteMoves(_turns, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(5, _gameState.Player.Position.X);
            Assert.AreEqual(4, _gameState.Player.Position.Y);
        }

        [Test]
        public void MoveExecutioner_ExecuteMove_PlayerMovesRight()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.Right);

            _turns.Enqueue(_gameState.Player);

            // Act
            _uut.ExecuteMoves(_turns, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(6, _gameState.Player.Position.X);
            Assert.AreEqual(5, _gameState.Player.Position.Y);
        }


        [Test]
        public void MoveExecutioner_ExecuteMove_PlayerMovesDown()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.Down);

            _turns.Enqueue(_gameState.Player);

            // Act
            _uut.ExecuteMoves(_turns, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(5, _gameState.Player.Position.X);
            Assert.AreEqual(6, _gameState.Player.Position.Y);
        }

        [Test]
        public void MoveExecutioner_ExecuteMove_PlayerMovesLeft()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.Left);

            _turns.Enqueue(_gameState.Player);

            // Act
            _uut.ExecuteMoves(_turns, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(4, _gameState.Player.Position.X);
            Assert.AreEqual(5, _gameState.Player.Position.Y);
        }


        [Test]
        public void MoveExecutioner_ExecuteMove_PlayerDoesNotMove()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.None);

            _turns.Enqueue(_gameState.Player);

            // Act
            _uut.ExecuteMoves(_turns, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(5, _gameState.Player.Position.X);
            Assert.AreEqual(5, _gameState.Player.Position.Y);
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
