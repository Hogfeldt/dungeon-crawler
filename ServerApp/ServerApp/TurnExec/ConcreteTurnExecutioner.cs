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
        private readonly IMoveExecutioner _moveExecutioner;

        public ConcreteTurnExecutioner(
            IMoveValidator validator,
            ICharacterFormatter formatter,
            ITurnScheduler scheduler,
            IMoveExecutioner executioner)
        {
            _validator = validator;
            _formatter = formatter;
            _turnScheduler = scheduler;
            _moveExecutioner = executioner;
        }

        public GameStateClass ExecuteTurn(GameStateClass state)
        {
            Player player = state.Player;
            ITile[,] tiles = state.Map.GetCurrentLayer().Tiles;
            var layer = state.Map.GetCurrentLayer();

            if (_validator.Validate(player.Position, player.NextMove, tiles))
            {
                List<ICharacter> characters = _formatter.ToList(layer.Characters);
                Queue<ICharacter> characterMoves = _turnScheduler.Schedule(characters);

                characters = _moveExecutioner.ExecuteMoves(characterMoves, layer);
            }

            return state;
        }
    }
}
