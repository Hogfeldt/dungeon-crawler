import { IGameState } from './IGameState';
import { IPlayer } from './IPlayer';
import { ILayer } from './ILayer';


export class GameState implements IGameState {
    public playerState: IPlayer;
    public layerState: ILayer;

    constructor(playerState: IPlayer, layerState: ILayer) {
        this.playerState = playerState;
        this.layerState     = layerState;
    }
}
