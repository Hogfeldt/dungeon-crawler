using NSubstitute;
using ServerApp.TurnExec;

using NUnit.Framework;
using ServerApp.GameState;

namespace IntegrationTest
{
    public class IntegrationsTest04_MoveValidator
    {
        private IMoveValidator _sut;

        private IGameState _gameState;
        //private IInteractionHandler _interactionHandler;
        
        private ITile[,] _tiles;

        [SetUp]
        public void Setup()
        {
            _sut = new MoveValidator();


            /*
             * Player starts in position 0,0
             * Valid moves from this position, based upon HardCodedLayerGenerator
             * is Down, and Right.
             * From Position Y = 1, one can move Up
             * From position X = 1, one can move Left
             */
            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(1, 1, 1), "john", 10)));

            //_interactionHandler = new InteractionHandler();
        }

        // === TEST MOVE VALIDATOR ===

        #region MoveValidator

        [Test]
        public void MoveValidator_ValidMoveUp_ReturnTrue()
        {
            _gameState.Player.Position = new Position(1,1);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Up, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(true, result);   
        }

        [Test]
        public void MoveValidator_ValidMoveUp_ReturnFalse()
        {
            _gameState.Player.Position = new Position(0,0);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Up, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MoveValidator_ValidMoveDown_ReturnTrue()
        {
            _gameState.Player.Position = new Position(0,0);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Down, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MoveValidator_ValidMoveDown_ReturnFalse()
        {
            _gameState.Player.Position = new Position(1,1);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Down, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MoveValidator_ValidMoveLeft_ReturnTrue()
        {
            _gameState.Player.Position = new Position(1,0);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Left, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MoveValidator_ValidMoveLeft_ReturnFalse()
        {
            _gameState.Player.Position = new Position(0,0);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Left, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void MoveValidator_ValidMoveRight_ReturnTrue()
        {
            _gameState.Player.Position = new Position(0,0);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Right, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void MoveValidator_ValidMoveRight_ReturnFalse()
        {
            _gameState.Player.Position = new Position(3,0);

            bool result = _sut.Validate(_gameState.Player.Position, Direction.Right, _gameState.Map.GetCurrentLayer().Tiles);
            Assert.AreEqual(false, result);
        }

        #endregion
    }
}