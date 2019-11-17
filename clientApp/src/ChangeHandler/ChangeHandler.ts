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
import { Position } from "../GameState/Position";


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

            return this.gameStateFromData(data);
        });
    }

    move(direction: string) {
        return this.api.move(direction).then(r => {

            var data = r.data;

            return this.gameStateFromData(data);

        });
    }

    private gameStateFromData(data: any): GameState {
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

        var spawnPos: Position = new Position(data.InitialPlayerPosition.X, data.InitialPlayerPosition.Y);
        var exitPos: Position = new Position(data.ExitPosition.X, data.ExitPosition.Y);
        var layer: ILayer = new Layer(tiles, spawnPos, exitPos);

        var characters: any[][] = new Array();
        for (var l = 0; l < data.Characters.length; l++) {
            characters[l] = [];
            for (var m = 0; m < data.Characters[l].length; m++) {
                if (data.Characters[l][m] != null) {
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
    }
}