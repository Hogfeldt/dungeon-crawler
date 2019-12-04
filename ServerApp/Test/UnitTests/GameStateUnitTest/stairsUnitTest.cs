using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;

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
            gameState = Substitute.For<IGameState>();        
            accendingStair = new AccendingStair();
            decendingStair = new DecendingStair();

            
        }

        [Test]
        public void accendingTest()
        {
            int layer_number_before = gameState.Map.CurrentLayerNumber;
            accendingStair.interact(gameState);
            Assert.True(layer_number_before-1 == gameState.Map.CurrentLayerNumber);
        }

        [Test]
        public void decendingTest()
        {
            int layer_number_before = gameState.Map.CurrentLayerNumber;
            accendingStair.interact(gameState);
            Assert.True(layer_number_before+1 == gameState.Map.CurrentLayerNumber);
        }
    }
}