using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface IInteractionHandler
    {
        GameStateClass Interact(GameStateClass state);
    }
}