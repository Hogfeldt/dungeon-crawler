using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;

namespace Test.UnitTests.GameStateUnitTest
{
    [TestFixture]
    class PLayerUnitTest //todo: Hpw test dis? Abstract klasse med interface??
    {
        private Player uut;
        private IPosition position;
        private IStats stats;

        [SetUp]
        public void setup()
        {
            position = Substitute.For<IPosition>();
            stats = Substitute.For<IStats>();
            uut = new Player(position, stats, "Karl", 20);
        }

        [Test]
        public void TestAddGold()
        {
            uut.AddGold(10);
            Assert.AreEqual(30, uut.Gold);
        }

        [Test]
        public void TestRemoveGoldSuccess()
        {
            uut.RemoveGold(10);
            Assert.AreEqual(10, uut.Gold);
        }

        [Test]
        public void TestRemoveGoldNotEnough()
        {
            Assert.Throws<NotEnoughGoldException>(() => uut.RemoveGold(50));
        }

        [Test]
        public void TestRemoveGoldNotEnoughThenRemoveAcceptableAmount()
        {
            Assert.Throws<NotEnoughGoldException>(() => uut.RemoveGold(50));
            Assert.AreEqual(20, uut.Gold);
            uut.RemoveGold(10);
            Assert.AreEqual(10, uut.Gold);
        }

        [Test]
        public void TestGetName()
        {
            Assert.AreEqual("Karl", uut.Name);
        }

        [Test]
        public void TestSetNextMove()
        {
            //Todo:: Make this test
        }

    }
}