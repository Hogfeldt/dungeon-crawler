namespace ServerApp.GameState
{
    public class DecendingStair : IInteractiveObject
    {
        public void interact(IGameState gameState)
        {
            Layer currentLayer = gameState.Map.GetCurrentLayer();
            Layer layerToDecent = gameState.Map.getLayerBelowOrNull();
            if (layerToDecent != null)
            {
                IPosition enteringPostion = layerToDecent.getEnteringPositionOrNull();
                if (enteringPostion != null) {
                    currentLayer.RemoveCharacterFromPosition(gameState.Player.Position);
                    gameState.Player.Position = enteringPostion;
                    layerToDecent.AddCharacter(gameState.Player);
                } 
            }
        }
    }
}
