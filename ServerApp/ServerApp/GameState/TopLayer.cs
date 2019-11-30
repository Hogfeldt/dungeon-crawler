using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class TopLayer : Layer
    {
        [JsonConstructor]
        public TopLayer(ITile[,] tiles, ICharacter[,] characters, IPosition ExitingPosition, IInteractiveObject[,] interactiveObjects)
        : base(tiles, characters, interactiveObjects)
        {
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