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

        [TestCase(20)]
        [TestCase(1)]
        [TestCase(0)]
        [Test]
        public void TestAddGoldSuccess(int gold)
        {
            uut.AddGold(gold);
            Assert.AreEqual(20+gold, uut.Gold);
        }

        [TestCase(-20)]
        [TestCase(-1)]
        [Test]
        public void TestAddGoldFail(int gold)
        {
            uut.AddGold(gold);
            Assert.AreEqual(20, uut.Gold);
        }



        [TestCase(20)]
        [TestCase(19)]
        [TestCase(0)]
        [Test]
        public void TestRemoveGoldSuccess(int gold)
        {
            Assert.IsTrue(uut.RemoveGold(gold));
            Assert.AreEqual(20-gold, uut.Gold);
        }

        [TestCase(50)]
        [TestCase(21)]
        [TestCase(-5)]
        [Test]
        public void TestRemoveGoldNotEnough(int gold)
        {
            Assert.IsFalse(uut.RemoveGold(gold));
            Assert.AreEqual(20, uut.Gold);
        }

        [Test]
        public void TestRemoveGoldNotEnoughThenRemoveAcceptableAmount()
        {
            Assert.IsFalse(uut.RemoveGold(50));
            Assert.AreEqual(20, uut.Gold);
            Assert.IsTrue(uut.RemoveGold(10));
            Assert.AreEqual(10, uut.Gold);
        }

        [Test]
        public void TestGetName()
        {
            Assert.AreEqual("Karl", uut.Name);
        }

        [TestCase(Character.Direction.None)]
        [TestCase(Character.Direction.Up)]
        [TestCase(Character.Direction.Down)]
        [TestCase(Character.Direction.Left)]
        [TestCase(Character.Direction.Right)]
        [Test]
        public void TestSetNextMove(Character.Direction direction)
        {
            uut.SetNextMove(direction);
            Assert.AreEqual(direction, uut.NextMove);
        }

    }
}