namespace ServerApp.GameState
{
    public class TopLayer : Layer
    {
        public TopLayer(ITile[,] tiles, ICharacter[,] characters, IPosition ExitingPosition, IInteractiveObject[,] interactiveObjects)
        {
            Tiles = tiles;
            Characters = characters;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            InteractiveObjects = interactiveObjects;
            this.ExitingPosition = ExitingPosition;
            initializeDecendingStair();
        }

        public override IPosition getEnteringPositionOrNull()
        {
            return null;
        }

        public override IPosition getExitingPositionOrNull()
        {
            return ExitingPosition;
        }
    }
}