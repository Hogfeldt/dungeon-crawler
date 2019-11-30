namespace ServerApp.GameState
{
    public interface IPlayer : ICharacter
    {
        int Gold { get; set; }
        int Experience { get; set; }
        void SetNextMove(Direction direction);
        bool AddGold(int gold);


    }
}