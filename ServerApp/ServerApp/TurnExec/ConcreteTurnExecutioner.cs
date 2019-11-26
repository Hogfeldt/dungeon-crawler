using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace ServerApp.TurnExec
{
    public class ConcreteTurnExecutioner : ITurnExecutioner
    {
        private readonly IMoveValidator _validator;
        private readonly ICharacterFormatter _formatter;
        private readonly ITurnScheduler _turnScheduler;

        public ConcreteTurnExecutioner(
            IMoveValidator validator,
            ICharacterFormatter formatter,
            ITurnScheduler scheduler)
        {
            _validator = validator;
            _formatter = formatter;
            _turnScheduler = scheduler;
        }

        public GameStateClass ExecuteTurn(GameStateClass state)
        {
            Player player = state.Player;
            ITile[,] tiles = state.Map.GetCurrentLayer().Tiles;

            if (_validator.Validate(player.Position, player.NextMove, tiles))
            {
                List<ICharacter> characters = _formatter.ToList(state.Map.GetCurrentLayer().Characters);
                Queue<ICharacter> turns = _turnScheduler.Schedule(characters);
            }

            return state;
        }
    }
}
