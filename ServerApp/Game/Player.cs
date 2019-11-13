using System;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace ServerApp.Game
{
    public class Player: Character
    {
        public int Layer { get; private set; }
        public int Gold { get; private set; } = 0;

        public Player(Position position, Stats stats, string name = "Player McName", int layer = 0): base(position, stats, name)
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

        public void SetNextMove(Character.Direction direction)
        {
            NextMove = direction;
        }
    }

    public class NotEnoughGoldException: Exception
    {
        public NotEnoughGoldException(string message): base(message)
        {
        }
    }
}