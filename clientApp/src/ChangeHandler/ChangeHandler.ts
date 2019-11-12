import { IApi } from "./IApi";
import { IGameState } from "../GameState/IGameState"
import { GameState } from "../GameState/GameState"
import { INPC } from "../GameState/INPC"
import { NPC } from "../GameState/NPC"
import { ICharacter } from "../GameState/ICharacter"
import { Character } from "../GameState/Character"
import { ILayer } from "../GameState/ILayer"
import { Layer } from "../GameState/Layer"
import { ITile } from "../GameState/ITile"
import { Tile } from "../GameState/Tile"


const mapSize = 10;


export class ChangeHandler {
    api: IApi;
    constructor(api:IApi) {
        this.api = api;
    }

    public getState() {
        return this.api.gameState().then(r => {
            console.log(r);

            var data = r.data;
            //var npcs: INPC[] = [];

            //for (var i = 0; i < data.NPCs.length; i++) {
            //    var npc = data.NPCs[i];
            //    npcs.push(new NPC(npc.x, npc.y));
            //}

            var tiles: any[][] = new Array();

            for (var j = 0; j < data.Tiles.length; j++) {
                tiles[j] = [];
                for (var k = 0; k < data.Tiles[j].length; k++) {

                    if (data.Tiles[j][k] != null) {
                        tiles[j][k] = new Tile(data.Tiles[j][k].Walkable);
                    } else {
                        tiles[j][k] = null;
                    }
                }
            }
            var layer: ILayer = new Layer(tiles);

            var NPCs: any[][] = new Array();
            for (var l = 0; l < data.NPCs.length; l++) {
                NPCs[l] = [];
                for (var m = 0; m < data.NPCs[l].length; m++) {
                    if (data.NPCs[l][m] != null) {
                        console.log(l, m);
                        NPCs[l][m] = new NPC(l, m);
                    } else {
                        NPCs[l][m] = null;
                    }
                }
            }

            var name: string = data.Player.name;
            var xPosition: number = data.Player.XPos;
            var yPosition: number = data.Player.YPos;
            var health: number = data.Player.Health;

            var character: ICharacter = new Character(name, xPosition, yPosition, health);

            var state = new GameState(NPCs, character, layer);
            
            return state;
        });
    }

    move(direction: string) {
        return this.api.move(direction);
    }
}