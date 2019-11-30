import { IPlayer } from './IPlayer';
import { ILayer } from './ILayer';

export interface IGameState {
    playerState: IPlayer;
    layerState: ILayer;
}
