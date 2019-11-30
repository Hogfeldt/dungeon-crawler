using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class CombatHandler : ICombatHandler
    {
        public void Fight(ICharacter attacker, ICharacter defender)
        {
            defender.TakeDamage(attacker.Stats.Damage);
            if (!defender.Alive)
            {
                defender.DropLoot();
            }
        }
    }
}
