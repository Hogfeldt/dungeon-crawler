﻿using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
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

        [SetUp]
        public void Setup()
        {
            _uut = new Movement();
            _layer = Substitute.For<ILayer>();
        }

        [Test]
        public void Testing()
        {
            _currentPosition = Substitute.For<IPosition>();
            _currentPosition.X.Returns(3);
            _currentPosition.X.Returns(3);

            _targetPosition = Substitute.For<IPosition>();
            _targetPosition.X.Returns(5);
            _targetPosition.X.Returns(5);

            _uut.MoveCharacter(_currentPosition, _targetPosition, _layer);
        }
    }
}
