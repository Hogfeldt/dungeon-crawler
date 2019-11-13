using System.Collections.Generic;

namespace ServerApp.Game
{
    public interface IMap
    {
        ILayer GetLayer(int layer);
    }
}