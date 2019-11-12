﻿namespace ServerApp.GameState
{
    public class Tile: ITile
    {
        public bool Walkable { set; get; } = true;

        public Tile()
        {

        }

        public Tile(bool walkable)
        {
            Walkable = walkable;
        }
    }
}