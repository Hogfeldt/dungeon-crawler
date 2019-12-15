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
            //uut = new HostileNPC(new Position(3, 1), new Stats(1, 1, 1), new StandStillMovementStrategy(), "Hurtigfar", 30); 
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

            player.AddGold(uut.DroppedGold);

            Assert.AreEqual(300, player.Gold);
        }

        [TestCase(10, 20)]
        [TestCase(0, 10)]
        [TestCase(10, 0)]
        [Test]
        public void TestDropExperienceToCharacter(int xp1, int xp2)
        {
            Player player = Substitute.For<Player>(position, stats, "SomePLayer", 100);
            IStats npcStats = Substitute.For<IStats>();
            npcStats.MaxHealth.Returns(xp1);
            npcStats.Damage.Returns(xp2);
            
            uut = new HostileNPC(position, npcStats, movementStrategy, "HostileName");
            player.AddExperience(xp1 * xp2);
            Assert.AreEqual(xp1 * xp2, player.Experience);
        }

    }
}