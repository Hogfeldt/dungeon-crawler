using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface IMap
    {
        int CurrentLayerNumber { get; }
        Layer GetCurrentLayer();
        Player GetPlayer();
        Layer getLayerBelowOrNull();
        Layer getLayerAboveOrNull();
    }
}