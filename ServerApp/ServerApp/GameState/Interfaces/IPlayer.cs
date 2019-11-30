namespace ServerApp.GameState
{
    public interface IPlayer
    {
        void AddExperience(int xp);
        bool AddGold(int gold);
        bool RemoveGold(int gold);
        void SetNextMove(Character.Direction direction);
    }
}