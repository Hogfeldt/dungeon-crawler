import { IApi} from "./IApi";
import { IGameState } from "../GameState/IGameState"

export class ChangeHandler {
    api: IApi;
    constructor(api:IApi) {
        this.api = api;
    }

    getState(): IGameState {
        throw new Error("Not implemented"); 
    }

    move(direction: string) {
        return this.api.move(direction);
    }
}