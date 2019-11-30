using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.TurnExecutionerUnitTest
{
    class CombatHandlerTest
    {
        private ICombatHandler _combatHandler;

        [SetUp]
        public void Setup()
        {
            _combatHandler = new CombatHandler();
        }

        [Test]
        public void CombatHandler_PlayerFightNpc_NpcDies()
        {
            var player = new Player(new Position(), new Stats(100, 10, 1), "player", 0);
            var npc = new HostileNPC(new Position(), new Stats(1, 1, 1), new StandStillMovementStrategy(), "enemy", 0);

            _combatHandler.Fight(player, npc);

            Assert.IsFalse(npc.Alive);
        }

        [Test]
        public void CombatHandler_PlayerFightNpc_PlayerDies()
        {
            var player = new Player(new Position(), new Stats(10, 10, 1), "player", 0);
            var npc = new HostileNPC(new Position(), new Stats(100, 10, 1), new StandStillMovementStrategy(), "enemy", 0);

            _combatHandler.Fight(player, npc);

            Assert.IsFalse(npc.Alive);
        }

        [Test]
        public void CombatHandler_PlayerFightNpc_SlowNpcDies()
        {
            // Both can kill each other, First strike wins
            var player = new Player(new Position(), new Stats(10, 10, 2), "player", 0);
            var npc = new HostileNPC(new Position(), new Stats(100, 10, 1), new StandStillMovementStrategy(), "enemy", 0);

            _combatHandler.Fight(player, npc);

            Assert.IsFalse(npc.Alive);
            Assert.IsTrue(player.Alive);
        }

        [Test]
        public void CombatHandler_PlayerFightNpc_SlowPlayerDies()
        {
            // Both can kill each other, First strike wins
            var player = new Player(new Position(), new Stats(10, 10, 1), "player", 0);
            var npc = new HostileNPC(new Position(), new Stats(10, 10, 2), new StandStillMovementStrategy(), "enemy", 0);

            _combatHandler.Fight(player, npc);

            Assert.IsTrue(npc.Alive);
            Assert.IsFalse(player.Alive);
        }
    }
}
