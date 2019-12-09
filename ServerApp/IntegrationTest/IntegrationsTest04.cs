﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace IntegrationTest
{
    public class IntegrationTest04
    {
        private IGameState _gameState;
        private ICharacter _npc;
        private IMovement _sut;


        [SetUp]
        public void Setup()
        {
            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));

            _sut = new Movement();
        }

        [Test]
        public void Movement()
        {
            // Arrange
            var currentPosition = new Position(3, 1);
            var newPosition = new Position(currentPosition.X, currentPosition.Y + 1);
            _npc = _gameState.Map.GetCurrentLayer().GetCharacter(currentPosition);


            // Act
            _sut.MoveCharacter(currentPosition, newPosition, _gameState.Map.GetCurrentLayer());

            // Assert
            Assert.AreEqual(newPosition.X, _npc.Position.X);
            Assert.AreEqual(newPosition.Y, _npc.Position.Y);

        }
    }
}
