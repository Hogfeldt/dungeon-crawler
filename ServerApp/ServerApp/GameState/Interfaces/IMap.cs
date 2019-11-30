using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface IMap
    {
        int CurrentLayerNumber { get; }
        ILayer GetCurrentLayer();
        IPlayer GetPlayer();
        ILayer getLayerBelowOrNull();
        ILayer getLayerAboveOrNull();
    }
}