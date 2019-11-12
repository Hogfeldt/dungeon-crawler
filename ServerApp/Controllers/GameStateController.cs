using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerApp.GameState;
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
            ILayerGenerator layerGenerator = new HardCodedLayerGenerator();
            Player player = new Player(new Position(0,0), new Stats(50, 10, 10));
            return Newtonsoft.Json.JsonConvert.SerializeObject(new ClientGameState(new GameState.GameState(player, new Map(layerGenerator,5))));
        }

        // GET: api/GameState/5
        [HttpGet("{id}", Name = "GetGameState")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GameState
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
