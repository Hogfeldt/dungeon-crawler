using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace ServerApp.TurnExec
{
    public class ConcreteTurnExecutioner : ITurnExecutioner
    {
        private readonly IMoveValidator _validator;

        public ConcreteTurnExecutioner(IMoveValidator validator)
        {
            _validator = validator;
        }

        public GameStateClass ExecuteTurn(GameStateClass state)
        {
            Player player = state.Player;
            ITile[,] tiles = state.Map.GetCurrentLayer().Tiles;

            if (_validator.Validate(player.Position, player.NextMove, tiles))
            {

            }

            return state;
        }
    }
}
