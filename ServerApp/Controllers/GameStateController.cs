using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.GameState;
using ServerApp.RequestHandler;
using Newtonsoft.Json;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStateController : ControllerBase
    {
        private static string SessionKeyGameState = "_GameState";

        public GameState.GameState GenerateNewGameState()
        {
            ILayerGenerator layerGenerator = new HardCodedLayerGenerator();
            Player player = new Player(new Position(0,0),new Stats(50, 10, 10), "PlayerBBoy123",0);

            return new GameState.GameState(player, new Map(layerGenerator, 5));
        }

        public GameState.GameState GetGameState()
        {
            var gameState = HttpContext.Session.Get<GameState.GameState>(SessionKeyGameState);
            if (gameState == null)
            {
                gameState = GenerateNewGameState();
                HttpContext.Session.Set<GameState.GameState>(SessionKeyGameState, gameState);
            }

            return gameState;
        }

        public void SetGameState(GameState.GameState gameState)
        {
            HttpContext.Session.Set<GameState.GameState>(SessionKeyGameState, gameState);
        }


        // GET: api/GameState
        [HttpGet]
        public string Get()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new ClientGameState(GetGameState()));
        }

        // GET: api/GameState/5
        [HttpGet("{id}", Name = "GetGameState")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GameState
        [HttpPost]
        public void Post(string value)
        {
            var gameState = GetGameState();
            gameState.Player.Descend();
            SetGameState(gameState);
        }

        // PUT: api/GameState/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
