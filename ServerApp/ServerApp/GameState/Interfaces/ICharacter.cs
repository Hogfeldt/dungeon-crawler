namespace ServerApp.GameState
{
    public interface ICharacter
    {
        string Name { get; }
        IPosition Position { set; get; }
        IStats Stats { set; get; }
        Character.Direction NextMove { get; }
        bool Alive { get; }
        int TakeDamage(int damage);
        void DropLoot();
    }
}