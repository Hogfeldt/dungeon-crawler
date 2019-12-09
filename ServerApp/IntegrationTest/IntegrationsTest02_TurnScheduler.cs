using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace IntegrationTest
{
    class IntegrationsTest02_TurnScheduler
    {
        public IGameState _gameState;
        public ITurnScheduler _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new TurnScheduler();

            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(2, 2, 2), "john", 10)));
        }

        [Test]
        public void TurnScheduler_Schedule_QueueSortedBySpeed()
        {
            IPosition npc_pos_1 = new Position(3, 1);
            IPosition npc_pos_2 = new Position(3, 4);
            IPosition npc_pos_3 = new Position(8, 4);
            IPosition playerPos = new Position(0, 0);

            ICharacter npc_1 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_1); // Speed = 1, Slowest
            ICharacter npc_2 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_2); // Speed = 2, Equal Speed to Player, but added first so it will dequeue before player (queue -> FIFO)
            ICharacter npc_3 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_3); // Speed = 10, Fastes
            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos); // Speed = 2

            List<ICharacter> characters = new List<ICharacter>();
            characters.Add(npc_1);
            characters.Add(npc_2);
            characters.Add(npc_3);
            characters.Add(player);

            Queue<ICharacter> charQueue = _sut.Schedule(characters);

            Assert.That(charQueue.Dequeue().Name == "Langsomfar");
            Assert.That(charQueue.Dequeue().Name == "Mellemhurtigfar");
            Assert.That(charQueue.Dequeue().Name == "john");
            Assert.That(charQueue.Dequeue().Name == "Hurtigfar");
        }

        [Test]
        public void TurnScheduler_Schedule_QueueReturnCorrectSpeed()
        {
            IPosition npc_pos_1 = new Position(3, 1);
            IPosition npc_pos_2 = new Position(3, 4);
            IPosition npc_pos_3 = new Position(8, 4);
            IPosition playerPos = new Position(0, 0);

            ICharacter npc_1 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_1);
            ICharacter npc_2 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_2);
            ICharacter npc_3 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_3);
            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos);

            List<ICharacter> characters = new List<ICharacter>();
            characters.Add(npc_1);
            characters.Add(npc_2);
            characters.Add(npc_3);
            characters.Add(player);

            Queue<ICharacter> charQueue = _sut.Schedule(characters);

            Assert.That(charQueue.Dequeue().Stats.Speed == 10);
            Assert.That(charQueue.Dequeue().Stats.Speed == 2);
            Assert.That(charQueue.Dequeue().Stats.Speed == 2);
            Assert.That(charQueue.Dequeue().Stats.Speed == 1);
        }

        [Test]
        public void TurnScheduler_Schedule_QueueNotSortedByFalseSpeed()
        {
            Position npc_pos_1 = new Position(3, 1);
            IPosition npc_pos_2 = new Position(3, 4);
            IPosition npc_pos_3 = new Position(8, 4);
            IPosition playerPos = new Position(0, 0);

            ICharacter npc_1 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_1);
            ICharacter npc_2 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_2);
            ICharacter npc_3 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_3);
            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos);

            List<ICharacter> characters = new List<ICharacter>();
            characters.Add(npc_1);
            characters.Add(npc_2);
            characters.Add(npc_3);
            characters.Add(player);

            Queue<ICharacter> charQueue = _sut.Schedule(characters);

            Assert.IsFalse(charQueue.Dequeue().Name == "Hurtigfar");
            Assert.IsFalse(charQueue.Dequeue().Name == "john");
            Assert.IsFalse(charQueue.Dequeue().Name == "Mellemhurtigfar");
            Assert.IsFalse(charQueue.Dequeue().Name == "Langsomfar");
        }
    }
}
