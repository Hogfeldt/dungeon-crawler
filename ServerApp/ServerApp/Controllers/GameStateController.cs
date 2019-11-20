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
