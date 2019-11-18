namespace ServerApp.GameState
{
    public class StandStillMovementStrategy: IMovementStrategy
    {
        public Character.Direction GenerateMove()
        {
            return Character.Direction.None;
        }
    }
}