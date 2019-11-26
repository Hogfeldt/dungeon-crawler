namespace ServerApp.GameState
{
    public class Chest : IInteractiveObject
    {
        public string Name {get;}
        public int goldContent {get; set;}

        public Chest() {
            Name = "Chest";
            goldContent = 100;
        }
        
        public void interact(IGameState gameState)
        {
            if(goldContent != 0) {
                gameState.Player.AddGold(goldContent);
                goldContent = 0;
            }
        }
    }
}