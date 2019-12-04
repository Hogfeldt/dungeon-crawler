using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class BottomLayer : Layer
    {
        [JsonConstructor]
        public BottomLayer(ITile[,] tiles, ICharacter[,] characters, IPosition EnteringPosition, IInteractiveObject[,] interactiveObjects)
        : base(tiles, characters, interactiveObjects)
        {
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