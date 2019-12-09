using NSubstitute;
using ServerApp.TurnExec;

using NUnit.Framework;
using ServerApp.GameState;

namespace IntegrationTest
{
    public class IntegrationTest03_InteractionHandler
    {
        private IGameState _gameState;
        private IInteractionHandler _sut;



        [SetUp]
        public void Setup()
        {
            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(), 
                    3, 
                    new Player(new Position(), new Stats(1, 1, 1), "john", 10)));

            _sut = new InteractionHandler();
        }

        [Test]
        public void InteractionHandler_PlayerStandsOnStairs_LayerNumberIsIncremented()
        {
            // Arrange
            _gameState.Player.Position = new Position(8, 5);

            // Act
            _sut.Interact(_gameState);

            // Assert
            Assert.AreEqual(1, _gameState.Map.CurrentLayerNumber);
        }

        [Test]
        public void InteractionHandler_PlayerDoesNotStandsOnStairs_LayerNumberIsIncremented()
        {
            // Arrange
            _gameState.Player.Position = new Position(0, 0);

            // Act
            _sut.Interact(_gameState);

            // Assert
            Assert.AreEqual(0, _gameState.Map.CurrentLayerNumber);
        }
    }
}