import { IApi } from "./IApi";
import { IGameState } from "../GameState/IGameState"
import { GameState } from "../GameState/GameState"
import { INPC } from "../GameState/INPC"
import { NPC } from "../GameState/NPC"
import { ICharacter } from "../GameState/ICharacter"
import { Character } from "../GameState/Character"
import { ILayer } from "../GameState/ILayer"
import { Layer } from "../GameState/Layer"


export default class ChangeHandler {
    api: IApi;
    constructor(api:IApi) {
        this.api = api;
    }

    public getState() {
        return this.api.gameState().then(r => {
            var data = r.data[0];
            var npcs: INPC[] = [];

            for (var i = 0; i < data.npcs.length; i++) {
                var npc = data.npcs[i];
                npcs.push(new NPC(npc.x, npc.y));
            }

            var layer: ILayer = new Layer();

            var name: string = data.player.name;
            var xPosition: number = data.player.yPosition;
            var yPosition: number = data.player.xPosition;
            var health: number = data.player.xPosition;

            var character: ICharacter = new Character(name, xPosition, yPosition, health);

            var state = new GameState(npcs, character, layer);
            
            return state;
        });
    }

    move(direction: string) {
        return this.api.move(direction);
    }
}