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
        return this.api.gameState().then(r => {
            console.log(r);

            var data = r.data;
            var npcs: INPC[] = [];

            for (var i = 0; i < data.NPCs.length; i++) {
                var npc = data.NPCs[i];
                npcs.push(new NPC(npc.x, npc.y));
            }

            var layer: ILayer = new Layer();

            var name: string = data.Player.name;
            var xPosition: number = data.Player.XPos;
            var yPosition: number = data.Player.YPos;
            var health: number = data.Player.Health;

            var character: ICharacter = new Character(name, xPosition, yPosition, health);

            var state = new GameState(npcs, character, layer);
            
            return state;
        });
    }

    move(direction: string) {
        return this.api.move(direction);
    }
}