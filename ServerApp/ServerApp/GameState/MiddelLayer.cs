namespace ServerApp.GameState
{
    public class MiddelLayer : Layer
    {
        public MiddelLayer(ITile[,] tiles, ICharacter[,] characters, IPosition ExitingPosition, IPosition EnteringPosition, IInteractiveObject[,] interactiveObjects)
        {
            Tiles = tiles;
            Characters = characters;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
            InteractiveObjects = interactiveObjects;
            this.ExitingPosition = ExitingPosition;
            this.EnteringPosition = EnteringPosition;
            initializeAccendigStair();
            initializeDecendingStair();
        }

        public override IPosition getEnteringPositionOrNull()
        {
            return EnteringPosition;
        }

        public override IPosition getExitingPositionOrNull()
        {
            return ExitingPosition;
        }
    }
}