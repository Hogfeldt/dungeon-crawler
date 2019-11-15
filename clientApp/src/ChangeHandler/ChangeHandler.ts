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

            //for (var i = 0; i < data.Characters.length; i++) {
            //    var npc = data.Characters[i];
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

            var characters: any[][] = new Array();
            for (var l = 0; l < data.Characters.length; l++) {
                characters[l] = [];
                for (var m = 0; m < data.Characters[l].length; m++) {
                    if (data.Characters[l][m] != null) {
                        console.log(l, m);
                        if (data.Characters[l][m].hasOwnProperty("Gold")) {
                            characters[l][m] = new Character(data.Characters[l][m].name,
                                l,
                                m,
                                data.Characters[l][m].Stats.MaxHealth);
                        } else {
                            characters[l][m] = new NPC(l, m);
                        }
                    } else {
                        characters[l][m] = null;
                    }
                }
            }

            var name: string = data.Player.Name;
            var xPosition: number = data.Player.Position.X;
            var yPosition: number = data.Player.Position.Y;
            var health: number = data.Player.Stats.CurrentHealth;

            var player: ICharacter = new Character(name, xPosition, yPosition, health);

            var state = new GameState(characters, player, layer);
            
            return state;
        });
    }

    move(direction: string) {
        return this.api.move(direction);
    }
}