// import { IGameState } from './GameState'


export class GameState {
    GameState: IGameState;
    

    constructor(gameState: IGameState) {
        GameState = gameState;
        
    }
    
    getCharState() {
        GameState
    }

    changeState(gameState: IGameState) {
        GameState = gameState;
    }
}
