using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;
using Test.UnitTests.Fakes;

namespace Test.UnitTests.GameStateUnitTest
{

    // TODO test corrcetly
    [TestFixture]
    class StairsUnitTest 
    {
        private IInteractiveObject accendingStair;
        private IInteractiveObject decendingStair;
        private IGameState gameState;

        [SetUp]
        public void setup()
        {
            //gameState = Substitute.For<IGameState>();        
            accendingStair = new AccendingStair();
            decendingStair = new DecendingStair();

            gameState = new GameStateClass(
                new Map(
                    new FakeLayer(),
                    2,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));


        }

        [Test]
        public void dummy()
        {
            return; 
        }
        
        
        [Test]
        public void decendingTest()
        {
            int layer_number_before = gameState.Map.CurrentLayerNumber;
            decendingStair.interact(gameState);
            Assert.True(layer_number_before+1 == gameState.Map.CurrentLayerNumber);
        }

        [Test]
        public void accendingTest()
        {

            decendingStair.interact(gameState);
            int layer_number_before = gameState.Map.CurrentLayerNumber;

            accendingStair.interact(gameState);
            Assert.True(layer_number_before - 1 == gameState.Map.CurrentLayerNumber);
        }

    }
}