using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;

namespace Test.UnitTests.GameStateUnitTest
{

    // TODO test corrcetly
    [TestFixture]
    class LayerUnitTest 
    {
        class DumbLayer : Layer
        {
            public DumbLayer(ITile[,] tiles, ICharacter[,] characters, IInteractiveObject[,] interactiveObjects) 
            : base(tiles, characters, interactiveObjects)
            {}

            public override IPosition getEnteringPositionOrNull()
            {
                throw new NotImplementedException();
            }

            public override IPosition getExitingPositionOrNull()
            {
                throw new NotImplementedException();
            }
        }

        private ITile[,] tiles;
        private ICharacter[,] characters;
        private IInteractiveObject[,] interactiveObjects;
        private Layer _uut;

        private int maxWidth = 8;
        private int maxHeight = 8;

        [SetUp]
        public void setup()
        {
            tiles = new ITile[maxWidth,maxHeight];
            characters = new ICharacter[maxWidth,maxHeight];
            interactiveObjects = new IInteractiveObject[maxWidth,maxHeight];
            _uut = new DumbLayer(tiles, characters, interactiveObjects);
        }

        // Testing PositionIsValid method
        private IPosition mockPosition(int x, int y)
        {
            IPosition position = Substitute.For<IPosition>();
            position.X.Returns(x);
            position.Y.Returns(y);
            return position;
        }

        [Test]
        public void positionIsValidGivenNegativeX()
        {
            Assert.False(_uut.PositionIsValid(mockPosition(-1,1)));
        }

        [Test]
        public void positionIsValidGivenNegativeY()
        {
            Assert.False(_uut.PositionIsValid(mockPosition(1,-1)));
        }

        [Test]
        public void positionIsValidGivenXBeyondMaxWidth()
        {
            Assert.False(_uut.PositionIsValid(mockPosition(maxWidth+1, 3)));
        }

        [Test]
        public void positionIsValidGivenYBeyondMaxHeight()
        {
            Assert.False(_uut.PositionIsValid(mockPosition(3, maxHeight+1)));
        }

        [Test]
        public void positionIsValidReturnsTrue()
        {
            Assert.True(_uut.PositionIsValid(mockPosition(3, 3)));
        }

        // Testing GetCharacter method
        [Test]
        public void addCharacterGetsCharacterWithInvalidPosition()
        {
            ICharacter character = Substitute.For<ICharacter>();
            IPosition position = mockPosition(maxHeight+5,3);
            character.Position.Returns(position);
            _uut.AddCharacter(character);
            CollectionAssert.DoesNotContain(_uut.Characters, character);
        }

        [Test]
        public void addCharacterGetsCharacterWithValidPosition()
        {
            ICharacter character = Substitute.For<ICharacter>();
            IPosition position = mockPosition(5,3);
            character.Position.Returns(position);
            _uut.AddCharacter(character);
            CollectionAssert.Contains(_uut.Characters, character);
        }
    }
}