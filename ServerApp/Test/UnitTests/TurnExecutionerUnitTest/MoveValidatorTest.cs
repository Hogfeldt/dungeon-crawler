using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class MoveValidatorTest
    {
        private IMoveValidator _uut;
        private ITile[,] _tiles;
        [SetUp]
        public void Setup()
        {
            _uut = new MoveValidator();
            _tiles = new ITile[2, 2]
            {
                { new Tile(false), new Tile(true)},
                { new Tile(true), new Tile(true) }
            };

        }

        [Test]
        public void MoveValidator_ValidMoveUp_ReturnsTrue()
        {
            IPosition position = new Position(1, 1);
            Character.Direction direction = Character.Direction.Up;

            bool result = _uut.Validate(position, direction, _tiles);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MoveValidator_InvalidMoveOutOfMap_ReturnsFalse()
        {
            IPosition position = new Position(1, 1);
            Character.Direction direction = Character.Direction.Down;

            bool result = _uut.Validate(position, direction, _tiles);

            Assert.AreEqual(false, result);
        }

    }
}
