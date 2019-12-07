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
    class CharacterFormatterTest
    {
        private ICharacterFormatter _uut;
        private ICharacter[,] _characterGrid;
        [SetUp]
        public void Setup()
        {
            _uut = new CharacterFormatter();
            _characterGrid = new ICharacter[,] { 
                {Substitute.For<ICharacter>(), Substitute.For<ICharacter>() },
                {Substitute.For<ICharacter>(), Substitute.For<ICharacter>()},
                {null, null}
            };
          
        }

        [Test]
        public void CharacterFormatter_ToListGiven3X2Array_returnsListLength4()
        {
            List<ICharacter> characters = _uut.ToList(_characterGrid);

            Assert.AreEqual(4, characters.Count);

            foreach (var character in characters)
            {
                Assert.AreNotEqual(null, character);
            }
        }
    }
}
