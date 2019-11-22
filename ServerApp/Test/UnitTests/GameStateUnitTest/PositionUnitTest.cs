using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;

namespace Test.UnitTests.GameStateUnitTest
{
    [TestFixture]
    class PosistionUnitTest 
    {
        private IPosition uut;
        [SetUp]
        public void setup()
        {
            uut = new Position(2, 4);
        }

        [Test]
        public void ValueConstructorTest()
        {
            Assert.AreEqual(2, uut.X);
            Assert.AreEqual(4, uut.Y);
        }

        [Test]
        public void PositionConstructorTest()
        {
            uut = new Position(uut);
            Assert.AreEqual(2, uut.X);
            Assert.AreEqual(4, uut.Y);
        }

        [Test]
        public void PositionOffsetConstructorTest()
        {
            uut = new Position(uut, 2, 2);
            Assert.AreEqual(4, uut.X);
            Assert.AreEqual(6, uut.Y);
        }

        [Test]
        public void SetPositionTest()
        {
            uut.X = 1;
            uut.Y = 9;
            Assert.AreEqual(1, uut.X);
            Assert.AreEqual(9, uut.Y);
        }
    }
}