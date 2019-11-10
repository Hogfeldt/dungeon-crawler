import { INPC } from "./INPC";
import { ICharacter } from "./ICharacter";
import { ILayer } from "./ILayer";

export interface IGameState {
    _NPCState:       INPC[];
    _CharacterState: ICharacter;
    _LayerState:     ILayer;
    

    changeState(gameState: IGameState): void;
}
