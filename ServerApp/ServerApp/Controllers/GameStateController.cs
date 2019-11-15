using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Game;
using ServerApp.RequestHandler;
using Newtonsoft.Json;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStateController : ControllerBase
    {
        // GET: api/GameState
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(new ClientGameState(SessionManager.GetGameState(HttpContext)));
        }

        // POST: api/GameState
        [HttpPost]
        public void Post(string value)
        {
            var gameState = SessionManager.GetGameState(HttpContext);
            gameState.Map.MovePlayerToNewLayer(gameState.Map.CurrentLayerNumber + 1);
            SessionManager.SetGameState(HttpContext, gameState);
        }
    }
}
