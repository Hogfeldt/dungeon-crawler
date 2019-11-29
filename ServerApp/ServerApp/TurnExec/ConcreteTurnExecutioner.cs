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
        private readonly IInteractionHandler _interactionHandler;

        public ConcreteTurnExecutioner(
            IMoveValidator validator,
            ICharacterFormatter formatter,
            ITurnScheduler scheduler,
            IMoveExecutioner executioner,
            IInteractionHandler interactionHandler)
        {
            _validator = validator;
            _formatter = formatter;
            _turnScheduler = scheduler;
            _moveExecutioner = executioner;
            _interactionHandler = interactionHandler;
        }

        public GameStateClass ExecuteTurn(GameStateClass state)
        {
            Player player = state.Player;
            ITile[,] tiles = state.Map.GetCurrentLayer().Tiles;
            var layer = state.Map.GetCurrentLayer();

            if (_validator.Validate(player.Position, player.NextMove, tiles))
            {
                List<ICharacter> characters = _formatter.ToList(layer.Characters);
                Queue<ICharacter> characterTurns = _turnScheduler.Schedule(characters);

                characters = _moveExecutioner.ExecuteMoves(characterTurns, layer);
                state.Map.GetCurrentLayer().Characters = _formatter.ToGrid(characters);

                state = _interactionHandler.Interact(state);
            }

            return state;
        }
    }
}
