using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NUnit.Framework;
using ServerApp.Game;

namespace Test
{
    [TestFixture]
    class FriendlyNPCTest
    {
        private FriendlyNPC uut;
        private IPosition position = Substitute.For<IPosition>();
        private IStats stats = Substitute.For<IStats>();
        private IMovementStrategy movementStrategy = Substitute.For<IMovementStrategy>();
        [SetUp]
        public void setup()
        {
            uut = new FriendlyNPC(position, stats, movementStrategy, "testName");
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
