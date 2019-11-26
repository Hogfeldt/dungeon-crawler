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
        [SetUp]
        public void Setup()
        {
            _uut = new MoveValidator();
        }

        [Test]
        public void MoveValidator_ValidMove_ReturnsTrue()
        {
            IPosition position = new Position(1, 1);
            Character.Direction direction = Character.Direction.Down;
            ITile[,] tiles = new ITile[2, 2]
            {
                { new Tile(true), new Tile(true)},
                { new Tile(true), new Tile(true) }
            };

            bool result = _uut.Validate(position, direction, tiles);

            Assert.AreEqual(true, result);

        }

    }
}
