using NSubstitute;
using ServerApp.TurnExec;

using NUnit.Framework;
using ServerApp.GameState;

namespace IntegrationTest
{
    public class IntegrationTest03
    {
        private IGameState _gameState;
        private ICombatHandler _sut;
        private ICharacter _npc;


        [SetUp]
        public void Setup()
        {
            _sut = new CombatHandler();
            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));

            _npc = new HostileNPC(new Position(2, 2), new Stats(1, 1, 1), new StandStillMovementStrategy(), "johnKiller", 30);
        }

        [Test]
        public void CombatHandler_PlayerFightNpc_NpcDies()
        {
            IPosition monsterPos = new Position(3,1);
            IPosition playerPos = new Position(0,0);

            ICharacter npc = _gameState.Map.GetCurrentLayer().GetCharacter(monsterPos);
            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos);
            
            _sut.Fight(player, npc, _gameState.Map.GetCurrentLayer());

            Assert.IsFalse(npc.Alive);
        }
        
        [Test]
        public void CombatHandler_PlayerFightNpc_PlayerGainLoot()
        {
            IPosition monsterPos = new Position(3, 1);
            IPosition playerPos = new Position(0, 0);

            ICharacter npc = _gameState.Map.GetCurrentLayer().GetCharacter(monsterPos);
            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos);

            _sut.Fight(player, npc, _gameState.Map.GetCurrentLayer());

            Assert.IsTrue(_gameState.Player.Gold == 40);
        }
        

        [Test]
        public void CombatHandler_PlayerFightNpc_PlayerDies()
        {
            IPosition monsterPos = new Position(3, 4);
            IPosition playerPos = new Position(0, 0);

            ICharacter npc = _gameState.Map.GetCurrentLayer().GetCharacter(monsterPos);
            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos);

            _sut.Fight(npc, player, _gameState.Map.GetCurrentLayer());

            Assert.IsFalse(player.Alive);
        }


        /* ------- Dont test this here, test elsewhere
        [Test]
        public void CombatHandler_PlayerFightNpc_SlowNpcDies()
        {
            // Both can kill each other, First strike wins
            
            IPosition monsterPos = new Position(3, 4);
            IPosition playerPos = new Position(0, 0);

            ICharacter npc = _gameState.Map.GetCurrentLayer().GetCharacter(monsterPos);
            npc.Stats = new Stats(1,10,1);

            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos);
            player.Stats = new Stats(1,10,2);
            

            _sut.Fight(npc, player, _gameState.Map.GetCurrentLayer());

            
            Assert.IsFalse(npc.Alive);
            Assert.IsTrue(player.Alive);
        }

        [Test]
        public void CombatHandler_PlayerFightNpc_SlowPlayerDies()
        {
            // Both can kill each other, First strike wins
            var player = new Player(new Position(), new Stats(10, 10, 1), "player", 0);
            var npc = new HostileNPC(new Position(), new Stats(10, 10, 2), new StandStillMovementStrategy(), "enemy", 0);

            _combatHandler.Fight(player, npc, layer);

            Assert.IsTrue(npc.Alive);
            Assert.IsFalse(player.Alive);
        }
        */
    }
}