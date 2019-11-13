using System.Collections.Generic;

namespace ServerApp.Game
{
    public interface IMap
    {
        int CurrentLayerNumber { get; }
        ILayer GetLayer(int layer);
        ILayer GetCurrentLayer();
        Player GetPlayer();
        void MovePlayerToNewLayer(int layer);
    }
}