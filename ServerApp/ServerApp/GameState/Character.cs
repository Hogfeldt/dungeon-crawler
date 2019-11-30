namespace ServerApp.GameState
{
    public abstract class Character : ICharacter
    {
        protected Character()
        {

        }


        public string Name { protected set; get; }
        public IPosition Position { set; get; }
        public IStats Stats { set; get; }
        public Direction NextMove { protected set; get; }

        public bool Alive { protected set; get; } = true;

        public enum Direction
        {
            None,
            Up,
            Down,
            Left,
            Right
        }

        protected Character(IPosition position, IStats stats, string name = "Character McDefaultName")
        {
            this.Position = position;
            this.Stats = stats;
            this.Name = name;
            this.NextMove = Direction.None;
        }

        public int TakeDamage(int damage)
        {
            this.Stats.TakeDamage(damage);
            if (this.Stats.CurrentHealth == 0)
            {
                this.Alive = false;
            }

            return this.Stats.CurrentHealth;
        }
    }
}