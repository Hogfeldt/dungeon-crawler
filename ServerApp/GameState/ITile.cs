using System;

namespace ServerApp.GameState
{
    public interface ITile
    {
        bool Walkable { get; set; }
    }
}