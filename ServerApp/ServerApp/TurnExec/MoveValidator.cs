using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class MoveValidator : IMoveValidator
    {
        public bool Validate(IPosition position, Character.Direction direction, ITile[,] tiles)
        {
            switch (direction)
            {
                case Character.Direction.Down:
                    if (position.Y + 1 > tiles.GetLength(1))
                    {
                        return false;
                    }
                    return tiles[position.X, position.Y + 1].Walkable;

                case Character.Direction.Up:
                    if (position.Y - 1 < 0)
                    {
                        return false;
                    }
                    return tiles[position.X, position.Y - 1].Walkable;

                case Character.Direction.Left:
                    if (position.X - 1 < 0)
                    {
                        return false;
                    }
                    return tiles[position.X - 1, position.Y].Walkable;


                case Character.Direction.Right:
                    if (position.X + 1 > tiles.GetLength(1))
                    {
                        return false;
                    }
                    return tiles[position.X + 1, position.Y].Walkable;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
