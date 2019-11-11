namespace ServerApp.GameState
{
    public class Tile: ITile
    {
        public Character Character { get; private set; } = null;

        public bool Walkable { set; get; }
        public bool Occupied { set; get; }
        public Tile(Character character)
        {
            this.Character = character;
        }

        public Tile()
        {

        }

        //Set the character of the tile, returns whatever was already on it (null or a Character object).
        public Character ReplaceCharacter(Character character)
        {
            Character old = Character;
            Character = character;

            return old;
        }

        public void RemoveCharacter()
        {
            Character = null;
        }


    }
}