namespace ServerApp.GameState
{
    public class StandStillMovementStrategy: IMovementStrategy
    {
        public Direction GenerateMove()
        {
            return Direction.None;
        }
    }
}