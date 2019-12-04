using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using ServerApp.GameState;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class MovementTest
    {
        private IMovement _uut;
        private ILayer _layer;

        private IPosition _currentPosition;
        private IPosition _targetPosition;

        private ICharacter _character;

        [SetUp]
        public void Setup()
        {
            _uut = new Movement();
            _layer = Substitute.For<ILayer>();
            _character = Substitute.For<ICharacter>();
        }

        [Test]
        public void MovementTest_PlayerMoves_CharacterIsUpdated()
        {
            _layer.PositionIsValid(Arg.Any<IPosition>()).Returns(true);
            _layer.GetCharacter(Arg.Is<IPosition>(c => c == _currentPosition)).Returns(_character);
            _layer.GetCharacter(Arg.Is<IPosition>(c => c == _targetPosition)).Returns((ICharacter) null);
            _layer.GetTile(Arg.Any<IPosition>()).Walkable.Returns(true);

            _currentPosition = Substitute.For<IPosition>();
            _currentPosition.X.Returns(3);
            _currentPosition.Y.Returns(3);

            _targetPosition = Substitute.For<IPosition>();
            _targetPosition.X.Returns(4);
            _targetPosition.Y.Returns(3);

            _character.Position.X.Returns(3);
            _character.Position.Y.Returns(3);

            _uut.MoveCharacter(_currentPosition, _targetPosition, _layer);


            Assert.AreEqual(_targetPosition, _character.Position);
        }

        [Test]
        public void MovementTest_PlayerMoves_GridIsUpdated()
        {
            _layer.PositionIsValid(Arg.Any<IPosition>()).Returns(true);
            _layer.GetCharacter(Arg.Is<IPosition>(c => c == _currentPosition)).Returns(_character);
            _layer.GetCharacter(Arg.Is<IPosition>(c => c == _targetPosition)).Returns((ICharacter)null);
            _layer.GetTile(Arg.Any<IPosition>()).Walkable.Returns(true);

            _currentPosition = Substitute.For<IPosition>();
            _currentPosition.X.Returns(3);
            _currentPosition.Y.Returns(3);

            _targetPosition = Substitute.For<IPosition>();
            _targetPosition.X.Returns(4);
            _targetPosition.Y.Returns(3);

            _character.Position.X.Returns(3);
            _character.Position.Y.Returns(3);

            _uut.MoveCharacter(_currentPosition, _targetPosition, _layer);


            Received.InOrder(() =>
            {
                _layer.RemoveCharacter(Arg.Is<ICharacter>(_character));
                _character.Position = _targetPosition;
                _layer.AddCharacter(Arg.Is<ICharacter>(_character));
            });

        }
    }
}
