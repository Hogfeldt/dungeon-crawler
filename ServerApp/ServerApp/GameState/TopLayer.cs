using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class TopLayer : Layer
    {
        public IPosition spawnPosition {get;}

        [JsonConstructor]
        public TopLayer(ITile[,] tiles, ICharacter[,] characters, IPosition ExitingPosition, IPosition spawnPosition, IInteractiveObject[,] interactiveObjects)
        : base(tiles, characters, interactiveObjects)
        {
            this.spawnPosition = spawnPosition;
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