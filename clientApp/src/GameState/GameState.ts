import { IGameState } from './GameState'


export class GameState implements IGameState {
    public _NPCState:       INPC;
    public _CharacterState: ICaracter;
    public _LayerState:     ILayer;

    constructor(npcState: INPC, characterState: ICharacter, layerState: ILayer) {
        this._NPCState       = npcState;
        this._CharacterState = characterState;
        this._LayerState     = layerState;
    }
    
    public changeState(gameState: IGameState) {
        this._NPCState       = gameState._NPCState;
        this._CharacterState = gameState._CharacterState;
        this._LayerState      = gameState._LayerState;
    }
}
