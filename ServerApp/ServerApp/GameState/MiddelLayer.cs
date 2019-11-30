using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class MiddelLayer : Layer
    {
        [JsonConstructor]
        public MiddelLayer(ITile[,] tiles, ICharacter[,] characters, IPosition ExitingPosition, IPosition EnteringPosition, IInteractiveObject[,] interactiveObjects) 
        : base(tiles, characters, interactiveObjects)
        {
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