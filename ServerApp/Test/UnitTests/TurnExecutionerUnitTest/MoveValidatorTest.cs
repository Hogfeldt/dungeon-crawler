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
            _tiles = new ITile[2, 2];

            _tiles[0, 0] = new Tile(true);
            _tiles[1, 0] = new Tile(false);
            _tiles[0, 1] = new Tile(true);
            _tiles[1, 1] = new Tile(true);


            /*      Grid should be as follows
            /      true   false
            /      true   false
            */
        }

        [Test]
        public void MoveValidator_ValidMoveUp_ReturnsTrue()
        {
            IPosition position = new Position(0, 1);
            Direction direction = Direction.Up;

            bool result = _uut.Validate(position, direction, _tiles);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MoveValidator_InvalidMoveOutOfMap_ReturnsFalse()
        {
            IPosition position = new Position(1, 1);
            Direction direction = Direction.Down;

            bool result = _uut.Validate(position, direction, _tiles);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void MoveValidator_ValidMoveLeft_ReturnsTrue()
        {
            IPosition position = new Position(1, 1);
            Direction direction = Direction.Left;

            bool result = _uut.Validate(position, direction, _tiles);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void MoveValidator_InvalidMoveUp_ReturnsFalse()
        {
            IPosition position = new Position(1, 0);
            Direction direction = Direction.Up;

            bool result = _uut.Validate(position, direction, _tiles);

            Assert.AreEqual(false, result);
        }

    }
}
