using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace IntegrationTest
{
    class IntegrationsTest08_TurnExecutioner
    {
        private ITurnExecutioner _sut;
        private IMoveExecutioner _moveExecutioner;
        private IMoveValidator _moveValidator;
        private IInteractionHandler _interactionHandler;
        private ITurnScheduler _turnScheduler;
        private ICharacterFormatter _characterFormatter;
        private IMovement _movement;
        private ICombatHandler _combatHandler;
        private IGameState _gameState;

        [SetUp]
        public void Setup()
        {
            _movement = new Movement();
            _combatHandler = new CombatHandler();
            _moveExecutioner = new MoveExecutioner(_combatHandler, _movement);

            _moveValidator = new MoveValidator();

            _interactionHandler = new InteractionHandler();

            _turnScheduler = new TurnScheduler();

            _characterFormatter = new CharacterFormatter();

            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));

            _sut = new ConcreteTurnExecutioner(
                _moveValidator,
                _characterFormatter,
                _turnScheduler,
                _moveExecutioner,
                _interactionHandler);
        }

        [Test]
        public void TurnExecutioner_ExecutesTurn_PlayerMovesRight()
        {
            // Arrange
            _gameState.Player.SetNextMove(Direction.Right);

            // Act
            _sut.ExecuteTurn(_gameState);

            // Assert
            Assert.AreEqual(1, _gameState.Player.Position.X);
            Assert.AreEqual(0, _gameState.Player.Position.Y);
        }

        [Test]
        public void TurnExecutioner_PlayerWalkOntoStairs_LayerIsChanged()
        {
            // Arrange
            _gameState.Player.Position = new Position(7, 5);

            // Moves player to the correct position. 
            _gameState.Map.GetCurrentLayer().AddCharacter(_gameState.Player);
            _gameState.Map.GetCurrentLayer().Characters[0, 0] = null;

            _gameState.Player.SetNextMove(Direction.Right);

            // Act
            _sut.ExecuteTurn(_gameState);

            // Assert
            Assert.AreEqual(1, _gameState.Map.CurrentLayerNumber);
        }
    }
}
