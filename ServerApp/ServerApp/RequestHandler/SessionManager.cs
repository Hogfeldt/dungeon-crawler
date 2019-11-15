using Microsoft.AspNetCore.Http;
using ServerApp.Game;

namespace ServerApp.RequestHandler
{
    public static class SessionManager
    {
        private static string SessionKeyGameState = "_GameState";
        
        public static Game.GameState GetGameState(HttpContext httpContext)
        {
            var gameState = httpContext.Session.Get<Game.GameState>(SessionKeyGameState);
            if (gameState == null)
            {
                gameState = GameStateFactory.GenerateNewGameState();
                httpContext.Session.Set<Game.GameState>(SessionKeyGameState, gameState);
            }

            return gameState;
        }

        public static void SetGameState(HttpContext httpContext, Game.GameState gameState)
        {
            httpContext.Session.Set<Game.GameState>(SessionKeyGameState, gameState);
        }
    }
}