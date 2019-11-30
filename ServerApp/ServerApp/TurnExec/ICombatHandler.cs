using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface ICombatHandler
    {
        void Fight(ICharacter attacker, ICharacter defender, ILayer layer);
    }
}