using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerApp.GameState;
using ServerApp.RequestHandler;
using ServerApp.TurnExec;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {

        // POST: api/Move
        [HttpPost]
        public string Post()
        {
            string value;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                value =  reader.ReadToEnd();
            }


            try
            {
                IGameState gameState = SessionManager.GetGameState(HttpContext);

                IMoveValidator validator = new MoveValidator();
                ICharacterFormatter characterFormatter = new CharacterFormatter();
                ITurnScheduler turnScheduler = new TurnScheduler();
                IMoveExecutioner moveExecutioner = new MoveExecutioner(new CombatHandler(), new Movement());
                IInteractionHandler interactionHandler = new InteractionHandler();
                ITurnExecutioner turnExecutioner = new ConcreteTurnExecutioner(validator, characterFormatter, turnScheduler, moveExecutioner, interactionHandler);

                var direction = StringToDirection(value);

                gameState = turnExecutioner.ExecuteTurn(gameState, direction);

                // GameState is casted since we only have one valid implementation of gamestate
                // Interface is for testability (interface needed for mocking)
                SessionManager.SetGameState(HttpContext, (GameStateClass)gameState);

                return JsonConvert.SerializeObject(new ClientGameState(SessionManager.GetGameState(HttpContext)));
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        public Direction StringToDirection(string value)
        {
            switch (value)
            {
                case "Up":
                    return Direction.Up;
                case "Down": 
                    return Direction.Down;
                case "Left":
                    return Direction.Left;
                case "Right":
                    return Direction.Right;
                default:
                    throw new FormatException("Value was " + value + " but should be a direction");
            }
        }
    }
}
