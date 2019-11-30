using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using ServerApp.GameState;

namespace Test.UnitTests.GameStateUnitTest
{
    [TestFixture]
    class StatsUnitTest
    {
        private IStats uut;
        [SetUp]
        public void Setup()
        {
            uut = new Stats(5, 6, 7);
        }

        
        [Test]
        public void TestSetSpeed()
        {
            uut.Speed = 10;
            Assert.AreEqual(10, uut.Speed);
        }

        [Test]
        public void TestSetDamage()
        {
            uut.Damage = 10;
            Assert.AreEqual(10, uut.Damage);
        }

        [Test]
        public void TestSetMaxHealth()
        {
            uut.MaxHealth = 10;
            Assert.AreEqual(10, uut.MaxHealth);
        }

        [Test]
        public void TestTakeDamage()
        {
            uut.ReduceHealt(2);
            Assert.AreEqual(3, uut.CurrentHealth);
        }

        [Test]
        public void TestGainHealth()
        { 
            uut.ReduceHealt(4);
            uut.GainHealth(3);
            Assert.AreEqual(4, uut.CurrentHealth);
        }


        [Test]
        public void TestConstructorParameters()
        {
            Assert.AreEqual(5, uut.MaxHealth);
            Assert.AreEqual(5, uut.CurrentHealth);
            Assert.AreEqual(6, uut.Damage);
            Assert.AreEqual(7, uut.Speed);
        }
    }
}