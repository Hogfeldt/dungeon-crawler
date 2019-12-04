namespace ServerApp.GameState
{
    public class AccendingStair : IInteractiveObject
    {
        public void interact(IGameState gameState)
        {
            ILayer currentLayer = gameState.Map.GetCurrentLayer();
            ILayer layerToAccend = gameState.Map.getLayerAboveOrNull();
            if (layerToAccend != null)
            {
                IPosition enteringPostion = layerToAccend.getExitingPositionOrNull();
                if (enteringPostion != null) {
                    ICharacter player = gameState.Player;
                    currentLayer.RemoveCharacter(player);
                    player.Position = enteringPostion;
                    layerToAccend.AddCharacter(player);
                    gameState.Map.setCurrentLayerToLayerAbove();
                } 
            }
        }
    }
}
