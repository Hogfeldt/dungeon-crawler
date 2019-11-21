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
    }
}
