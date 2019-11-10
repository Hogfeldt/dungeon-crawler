export interface IGameState {
    _NPCState:       INPC;
    _CharacterState: ICaracter;
    _LayerState:     ILayer;
    

    changeState(gameState: IGameState): void;
}
