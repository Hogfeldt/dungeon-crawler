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
                IPosition enteringPostion = layerToAccend.getEnteringPositionOrNull();
                if (enteringPostion != null) {
                    currentLayer.RemoveCharacterFromPosition(gameState.Player.Position);
                    gameState.Player.Position = enteringPostion;
                    layerToAccend.AddCharacter(gameState.Player);
                } 
            }
        }
    }
}
