namespace ServerApp.GameState
{
    public class Chest : IInteractiveObject
    {
        public string Name {get;}

        public Chest() {
            Name = "Chest";
        }
        
        public void interact()
        {
            // TODO: Make smarter
        }
    }
}