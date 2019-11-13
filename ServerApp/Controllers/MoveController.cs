using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerApp.Game;
using ServerApp.RequestHandler;
using ServerApp.TurnExec;

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
        public string Post([FromBody] string value)
        {
            try
            {
                var direction = StringToDirection(value);
                var gameState = SessionManager.GetGameState(HttpContext);
                gameState.Player.SetNextMove(direction);
                SessionManager.SetGameState(HttpContext, TurnExecutioner.Execute(gameState));

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
