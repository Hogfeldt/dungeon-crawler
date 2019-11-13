namespace ServerApp.Game
{
    public interface ILayerGenerator
    { 
        ILayer GenerateLayer(int layerNumber);
    }
}