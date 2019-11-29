using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerApp.GameState;
using ServerApp.RequestHandler;
using ServerApp.TurnExec;
using ServerApp.TurnExecute;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(Player.Direction.Up);
        }

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
                var direction = StringToDirection(value);
                var gameState = SessionManager.GetGameState(HttpContext);
                gameState.Player.SetNextMove(direction);
                gameState.Map.GetPlayer().SetNextMove(direction);


                IMoveValidator validator = new MoveValidator();
                ICharacterFormatter characterFormatter = new CharacterFormatter();
                ITurnScheduler turnScheduler = new TurnScheduler();
                IMoveExecutioner moveExecutioner = new MoveExecutioner(new CombatHandler());
                IInteractionHandler interactionHandler = 
                ITurnExecutioner turnExecutioner = new ConcreteTurnExecutioner(validator, characterFormatter, turnScheduler, moveExecutioner);

                gameState = turnExecutioner.ExecuteTurn(gameState);

                SessionManager.SetGameState(HttpContext, gameState);

                return JsonConvert.SerializeObject(new ClientGameState(SessionManager.GetGameState(HttpContext)));
            }
            catch (ArgumentException e)
            {
                return e.Message;
            }
        }

        public Character.Direction StringToDirection(string value)
        {
            switch (value)
            {
                case "Up":
                    return Character.Direction.Up;
                case "Down": 
                    return Character.Direction.Down;
                case "Left":
                    return Character.Direction.Left;
                case "Right":
                    return Character.Direction.Right;
                default:
                    throw new FormatException("Value was " + value + " but should be a direction");
            }
        }
    }
}
