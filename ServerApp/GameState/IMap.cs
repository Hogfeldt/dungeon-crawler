using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface IMap
    {
        ILayer GetLayer(int layer);
    }
}