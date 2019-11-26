namespace ServerApp.GameState
{
    public class ChestMimic : IInteractiveObject
    {
        public string Name {get;}
        public int damage {get; set;}
        public bool discovered {get;set;}

        public ChestMimic() {
            Name = "ChestMimic";
            damage = 10;
            discovered = false;
        }
        
        public void interact(IGameState gameState)
        {
            gameState.Player.TakeDamage(damage);
            discovered = true;
        }
    }
}