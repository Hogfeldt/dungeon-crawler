﻿using System;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace ServerApp.Game
{
    public class Player: Character
    {
        public int Gold { get; private set; }

        public Player(Position position, Stats stats, string name = "Player McName", int gold = 15) : base(position, stats, name)
        {
            Gold = gold;
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