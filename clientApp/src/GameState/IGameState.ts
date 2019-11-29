import { INPC } from './INPC';
import { ICharacter } from './ICharacter';
import { ILayer } from './ILayer';

export interface IGameState {
    NPCState: INPC[][];
    characterState: ICharacter;
    layerState: ILayer;

    changeState(gameState: IGameState): void;
}
