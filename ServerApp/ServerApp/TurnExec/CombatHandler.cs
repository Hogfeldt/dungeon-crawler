using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class CombatHandler : ICombatHandler
    {
        public void Fight(ICharacter attacker, ICharacter defender, ILayer layer)
        {
            defender.TakeDamage(attacker.Stats.Damage);
            if (!defender.Alive)
            {
                int goldToLoot = defender.DropLoot();
                attacker.AddGold(goldToLoot);
                layer.RemoveCharacter(defender);
            }
        }
    }
}
