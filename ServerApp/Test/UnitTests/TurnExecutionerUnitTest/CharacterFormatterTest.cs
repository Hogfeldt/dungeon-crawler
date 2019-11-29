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

        [Test]
        public void CharacterFormatter_ToGridGivenListContaining3NPC_Returns10x10Grid()
        {
            List<ICharacter> characters = new List<ICharacter>();

            characters.Add(new HostileNPC(new Position(1, 2), new Stats(), new StandStillMovementStrategy(), "bad boi 1"));
            characters.Add(new HostileNPC(new Position(4, 1), new Stats(), new StandStillMovementStrategy(), "bad boi 2"));
            characters.Add(new HostileNPC(new Position(7, 5), new Stats(), new StandStillMovementStrategy(), "bad boi 3"));

            ICharacter[, ] charactersGrid = _uut.ToGrid(characters);

            Assert.AreEqual("bad boi 1", charactersGrid[1, 2].Name);
            Assert.AreEqual("bad boi 2", charactersGrid[4, 1].Name);
            Assert.AreEqual("bad boi 3", charactersGrid[7, 5].Name);
        }
    }
}
