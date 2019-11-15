using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using ServerApp.GameState;

namespace Test.UnitTests.GameStateUnitTest
{
    [TestFixture]
    class HostileNPCUnitTest
    {
        private HostileNPC uut;
        private IPosition position = Substitute.For<IPosition>();
        private IStats stats = Substitute.For<IStats>();
        private IMovementStrategy movementStrategy = Substitute.For<IMovementStrategy>();
        [SetUp]
        public void setup()
        {
            uut = new HostileNPC(position, stats, movementStrategy, "HostileName");
        }

        [Test]
        public void TestGetHostileName()
        {
            Assert.AreEqual("HostileName", uut.Name);
        }

        [Test]
        public void TestDropGoldToCharacter()
        {
            Player player = Substitute.For<Player>(position, stats, "SomePLayer", 100);
            uut.DroppedGold = 200;
            uut.DropGoldToCharacter(player);
            Assert.AreEqual(300, player.Gold);
        }

    }
}