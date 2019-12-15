﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace IntegrationTest
{
    class IntegrationsTest07_MoveExecutioner
    {
        private IGameState _gameState;
        private IMovement _movement;
        private ICombatHandler _combatHandler;
        private IMoveExecutioner _sut;

        private Queue<ICharacter> _turns;

        [SetUp]
        public void Setup()
        {
            _movement = new Movement();
            _combatHandler = new CombatHandler();

            _sut = new MoveExecutioner(_combatHandler, _movement);

            _turns = new Queue<ICharacter>();

            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));
        }


        [Test]
        public void TurnExecutioner_PlayerNextMoveValid_PlayerMovesRight()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.Right);
            _turns.Enqueue(_gameState.Player);

            // Act
            _sut.ExecuteMoves(_turns, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(1, _gameState.Player.Position.X);
            Assert.AreEqual(0, _gameState.Player.Position.Y);
        }

        [Test]
        public void TurnExecutioner_PlayerNextMoveInvalid_PlayerHasNotMoved()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.Up);
            _turns.Enqueue(_gameState.Player);

            // Act
            _sut.ExecuteMoves(_turns, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(0, _gameState.Player.Position.X);
            Assert.AreEqual(0, _gameState.Player.Position.Y);
        }
    }
}
