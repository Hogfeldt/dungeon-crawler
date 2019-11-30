namespace ServerApp.GameState
{
    public class BottomLayer : Layer
    {
        public BottomLayer(ITile[,] tiles, ICharacter[,] characters, IPosition EnteringPosition, IInteractiveObject[,] interactiveObjects)
        {
            Tiles = tiles;
            Characters = characters;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            InteractiveObjects = interactiveObjects;
            this.EnteringPosition = EnteringPosition;
            initializeAccendigStair();
        }

        public override IPosition getEnteringPositionOrNull()
        {
            return EnteringPosition;
        }

        public override IPosition getExitingPositionOrNull()
        {
            return null;
        }
    }
}