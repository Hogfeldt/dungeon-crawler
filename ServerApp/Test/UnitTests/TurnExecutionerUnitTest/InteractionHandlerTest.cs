using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class InteractionHandlerTest
    {
        private IInteractionHandler _uut;
        private IInteractiveObject[, ] _interactiveObjects;
        private IGameState _state;
        private ICharacter _player;

        [SetUp]
        public void Setup()
        {
            _uut = new InteractionHandler();

            _state = Substitute.For<IGameState>();
            _player = Substitute.For<IPlayer>();

            _player.Position.X.Returns(5);
            _player.Position.Y.Returns(5);

            _interactiveObjects = new IInteractiveObject[10, 10];

            _state.Player.Returns(_player);

            _state.Map.GetCurrentLayer().InteractiveObjects.Returns(_interactiveObjects);
        }

        [Test]
        public void InteractionHandler_GameStateWithOneInteractive_InteractIsCalled()
        {
            IInteractiveObject interactiveMock = Substitute.For<IInteractiveObject>();
            _interactiveObjects[5, 5] = interactiveMock;

            _state = _uut.Interact(_state);

            interactiveMock.Received().interact(Arg.Any<IGameState>());
        }

        [Test]
        public void InteractionHandler_GameStateWithOneInteractive_InteractIsNotCalled()
        {
            IInteractiveObject interactiveMock = Substitute.For<IInteractiveObject>();
            _interactiveObjects[5, 1] = interactiveMock;

            _state = _uut.Interact(_state);

            interactiveMock.DidNotReceive().interact(Arg.Any<IGameState>());
        }
    }
}
