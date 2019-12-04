namespace ServerApp.GameState
{
    public class DecendingStair : IInteractiveObject
    {
        public void interact(IGameState gameState)
        {
            ILayer currentLayer = gameState.Map.GetCurrentLayer();
            ILayer layerToDecent = gameState.Map.getLayerBelowOrNull();
            if (layerToDecent != null)
            {
                IPosition enteringPostion = layerToDecent.getEnteringPositionOrNull();
                if (enteringPostion != null) {
                    ICharacter player = gameState.Player;
                    currentLayer.RemoveCharacter(player);
                    player.Position = enteringPostion;
                    layerToDecent.AddCharacter(player);
                    gameState.Map.setCurrentLayerToLayerBelow();
                } 
            }
        }
    }
}
