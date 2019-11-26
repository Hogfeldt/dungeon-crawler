using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class CombatHandler : ICombatHandler
    {
        public void Fight(ICharacter attacker, ICharacter defender)
        {
            if (attacker.GetType() == typeof(Player) && defender.GetType() == typeof(HostileNPC))
            {
                //character is Player and characterOnTile is HostileNPC, Player punches HostileNPC
                PlayerFightHostileNPC((Player)attacker, (HostileNPC)defender);

            }
            else if (attacker.GetType() == typeof(HostileNPC) && defender.GetType() == typeof(Player))
            {
                //character is HostileNPC and characterOnTile is Player, HostileNPC punches Player.
                HostileNPCFightPlayer((HostileNPC)attacker);
            }
        }

        private void PlayerFightHostileNPC(Player player, HostileNPC hostile)
        {
            hostile.TakeDamage(player.Stats.Damage);
            if (!hostile.Alive)
            {
                //The monster died - Award gold and experience to player
                hostile.DropToCharacter(player);

                //Save the monster position so that we can move the player after cleaning the layer.
                player.Position = hostile.Position;
            }
        }

        private void HostileNPCFightPlayer(HostileNPC hostile)
        {
            //Punch the player and ????????????????? if they die.
            throw new NotImplementedException("HostileNPCFightPlayer isn't implemented yet");
        }
    }


}
