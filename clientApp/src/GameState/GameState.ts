import { IGameState } from './IGameState';
import { INPC } from './INPC';
import { ICharacter } from './ICharacter';
import { ILayer } from './ILayer';


export class GameState implements IGameState {
    public NPCState: INPC[][];
    public characterState: ICharacter;
    public layerState: ILayer;

    constructor(npcState: INPC[][], characterState: ICharacter, layerState: ILayer) {
        this.NPCState       = npcState;
        this.characterState = characterState;
        this.layerState     = layerState;
    }

    public changeState(gameState: IGameState) {
        this.NPCState       = gameState.NPCState;
        this.characterState = gameState.characterState;
        this.layerState      = gameState.layerState;
    }
}
