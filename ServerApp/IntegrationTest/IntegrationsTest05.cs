﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace IntegrationTest
{
    class IntegrationsTest05
    {
        public IGameState _gameState;
        public ICharacterFormatter _sut;
        private ICharacter[,] _characterGrid;

        [SetUp]
        public void SetUp()
        {
            _sut = new CharacterFormatter();

            _gameState = new GameStateClass(
                new Map(
                    new HardCodedLayerGenerator(),
                    3,
                    new Player(new Position(), new Stats(2, 2, 1), "john", 10)));

            IPosition npc_pos_1 = new Position(3, 1);
            IPosition npc_pos_2 = new Position(3, 4);
            IPosition npc_pos_3 = new Position(8, 4);
            IPosition playerPos = new Position(0, 0);

            ICharacter npc_1 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_1);
            ICharacter npc_2 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_2);
            ICharacter npc_3 = _gameState.Map.GetCurrentLayer().GetCharacter(npc_pos_3);
            ICharacter player = _gameState.Map.GetCurrentLayer().GetCharacter(playerPos);

            _characterGrid = new ICharacter[,] {
                {player, npc_1 },
                {npc_2, npc_3}
            };
        }

        [Test]
        public void Characterformatter_ToList_AllCharacterFromLayerAdded()
        {
            List<ICharacter> allCharacters = _sut.ToList(_characterGrid);
            Assert.AreEqual(4, allCharacters.Count);
        }

    }
}
