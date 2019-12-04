using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class TurnSchedulerTest
    {
        private ITurnScheduler _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new TurnScheduler();
        }

        [Test]
        public void TurnScheduler_ScheduleCalled_returnsQueue()
        {
            List<ICharacter> characters = new List<ICharacter>();

            characters.Add(Substitute.For<ICharacter>());
            characters[0].Stats.Speed.Returns(2);

            characters.Add(Substitute.For<ICharacter>());
            characters[1].Stats.Speed.Returns(1);

            characters.Add(Substitute.For<ICharacter>());
            characters[2].Stats.Speed.Returns(5);

            Queue<ICharacter> characterQueue = _uut.Schedule(characters);

            Assert.AreEqual(5, characterQueue.Dequeue().Stats.Speed);
            Assert.AreEqual(2, characterQueue.Dequeue().Stats.Speed);
            Assert.AreEqual(1, characterQueue.Dequeue().Stats.Speed);
        }
    }
}
