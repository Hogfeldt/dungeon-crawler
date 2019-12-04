using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface IInteractionHandler
    {
        void Interact(IGameState state);
    }
}