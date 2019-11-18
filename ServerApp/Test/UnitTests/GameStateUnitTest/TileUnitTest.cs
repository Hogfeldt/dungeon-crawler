using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using ServerApp.GameState;

namespace Test.UnitTests.GameStateUnitTest
{
    [TestFixture]
    class TileUnitTest
    {
        private ITile uut;
        [SetUp]
        public void Setup()
        {
            uut = new Tile();
        }

        [TestCase(true)]
        [TestCase(false)]
        [Test]
        public void TestWalkable(bool walkable)
        {
            uut.Walkable = walkable;
            Assert.AreEqual(walkable, uut.Walkable);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Test]
        public void TestWalkableConstructor(bool walkable)
        {
            uut = new Tile(walkable);
            Assert.AreEqual(walkable, uut.Walkable);
        }

    }
}