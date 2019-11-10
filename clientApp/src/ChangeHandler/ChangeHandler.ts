import { IApi } from "./IApi";
import { IGameState } from "../GameState/IGameState"
import { GameState } from "../GameState/GameState"
import { INPC } from "../GameState/INPC"
import { NPC } from "../GameState/NPC"
import { ICharacter } from "../GameState/ICharacter"
import { Character } from "../GameState/Character"
import { ILayer } from "../GameState/ILayer"
import { Layer } from "../GameState/Layer"


export class ChangeHandler {
    api: IApi;
    constructor(api:IApi) {
        this.api = api;
    }

    public getState() {
        this.api.gameState().then((r) => {
            var npcs: NPC[] = [];
            npcs[0] = new NPC(1, 2);
            npcs[1] = new NPC(3, 4);

            var layer: ILayer = new Layer();

            var name:string = r.data["player"].name;
            var xPosition:number = r.data["player"].yPosition;
            var yPosition: number = r.data["player"].xPosition;
            var health: number = r.data["player"].xPosition;

            var character: ICharacter = new Character(name, xPosition, yPosition, health);

            var state = new GameState(npcs, character, layer);
            return state;
        });
    }

    move(direction: string) {
        return this.api.move(direction);
    }
}