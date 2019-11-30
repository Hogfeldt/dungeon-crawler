namespace ServerApp.GameState
{
    public interface IStats
    {
        int MaxHealth { get; set; }
        int CurrentHealth { get; set; }
        int Damage { get; set; }
        int Speed { get; set; }
        void TakeDamage(int damage);
        void GainHealth(int health);
    }
}