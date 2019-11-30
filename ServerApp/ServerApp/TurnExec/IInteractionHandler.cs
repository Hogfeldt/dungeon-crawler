using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface IInteractionHandler
    {
        IGameState Interact(IGameState state);
    }
}