﻿using NSubstitute;
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
            _player = Substitute.For<ICharacter>();

            _player.Position.X.Returns(5);
            _player.Position.X.Returns(5);

            _interactiveObjects = new IInteractiveObject[10, 10];

            _state.Map.GetCurrentLayer().Returns(Substitute.For<ILayer>());
            _state.Player.Returns(_player);
        }

        [Test]
        public void InteractionHandler_GameStateWithOneInteractive_InteractIsCalled()
        {
            _interactiveObjects = new IInteractiveObject[10, 10];
            IInteractiveObject interactiveMock = Substitute.For<IInteractiveObject>();
            _interactiveObjects[5, 5] = Substitute.For<IInteractiveObject>();

            _state = _uut.Interact(_state);

            interactiveMock.Received().interact(Arg.Any<IGameState>());
        }
    }
}
