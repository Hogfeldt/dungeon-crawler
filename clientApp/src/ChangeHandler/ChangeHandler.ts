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
import { InteractiveObject } from '@/GameState/InteractiveObject';


const mapSize = 10;


export class ChangeHandler {
    api: IApi;
    constructor(api:IApi) {
        this.api = api;
    }

    public getState() {
        return this.api.gameState().then(r => {

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

    public postUserInfo(username: string, password: string, email: string) {
        return this.api.postUserInfo(username, password, email).then(r => {
            return r.data;
        });
    }

    public getUserInfo(username: string, password: string, email: string) {
        return this.api.getUserInfo(username, password).then(r => {
            return r.data;
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
        var interactiveObjects: (InteractiveObject | null)[][] = []
        for(var i=0; i<data.InteractiveObjects.length; i++) {
            var temp: (InteractiveObject | null)[] = [];
            for (var j=0; j<data.InteractiveObjects[i].length; j++) {
                if (data.InteractiveObjects[i][j] != null) {
                    temp.push(new InteractiveObject(data.InteractiveObjects[i][j].Name, data.InteractiveObjects[i][j].goldContent));
                } else {
                    temp.push(null);
                }
            }
            interactiveObjects.push(temp);
        } 
        var layer: ILayer = new Layer(tiles, spawnPos, exitPos, interactiveObjects);

        var name: string = data.Player.Name;
        var xPosition: number = data.Player.Position.X;
        var yPosition: number = data.Player.Position.Y;
        var health: number = data.Player.Stats.CurrentHealth;
        var maxHealth: number = data.Player.Stats.MaxHealth;
        var gold: number = data.Player.Gold;
        var experience: number = data.Player.Experience;

        var player: ICharacter = new Character(name, xPosition, yPosition, health, maxHealth, gold, experience);

        var characters: any[][] = new Array();
        for (var l = 0; l < data.Characters.length; l++) {
            characters[l] = [];
            for (var m = 0; m < data.Characters[l].length; m++) {
                if (data.Characters[l][m] != null) {
                    var currentCharacter: any = data.Characters[l][m];
                    if (currentCharacter.hasOwnProperty("Gold")) {
                        characters[l][m] = player;
                    } else {
                        characters[l][m] = new NPC(currentCharacter.Position.x, currentCharacter.Position.Y);
                    }
                } else {
                    characters[l][m] = null;
                }
            }
        }


        var state = new GameState(characters, player, layer);

        return state;
    }
}