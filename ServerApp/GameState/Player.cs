using System;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace ServerApp.GameState
{
    public class Player: Character
    {
        public int Layer { get; private set; }
        public int Gold { get; private set; }

        public Player(uint xPos, uint yPos, uint maxHealth, uint damage, uint speed, int layer): base(xPos, yPos, maxHealth, damage, speed)
        {
            Layer = layer;
        }

        public void Ascend()
        {
            if (Layer > 0) {
                Layer -= 1;
            }
        }

        public void Descend()
        {
            Layer += 1;
        }

        public void AddGold(int gold)
        {
            Gold += gold;
        }

        public void RemoveGold(int gold)
        {
            if(Gold < gold)
            {
                throw new NotEnoughGoldException("Not enough gold!");
            } else
            {
                Gold -= gold;
            }
        }
    }

    public class NotEnoughGoldException: Exception
    {
        public NotEnoughGoldException(string message): base(message)
        {
        }
    }
}