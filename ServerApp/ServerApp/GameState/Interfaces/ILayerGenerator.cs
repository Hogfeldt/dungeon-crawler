﻿namespace ServerApp.GameState
{
    public interface ILayerGenerator
    { 
        ILayer GenerateLayer(int layerNumber);
    }
}