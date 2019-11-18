using Microsoft.AspNetCore.Http;
using ServerApp.GameState;

namespace ServerApp.RequestHandler
{
    public static class SessionManager
    {
        private static string SessionKeyGameState = "_GameState";
        
        public static GameState.GameStateClass GetGameState(HttpContext httpContext)
        {
            var gameState = httpContext.Session.Get<GameState.GameStateClass>(SessionKeyGameState);
            if (gameState == null)
            {
                gameState = GameStateFactory.GenerateNewGameState();
                httpContext.Session.Set<GameState.GameStateClass>(SessionKeyGameState, gameState);
            }

            return gameState;
        }

        public static void SetGameState(HttpContext httpContext, GameState.GameStateClass gameState)
        {
            httpContext.Session.Set<GameState.GameStateClass>(SessionKeyGameState, gameState);
        }
    }
}