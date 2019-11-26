import { IApi } from './IApi';
import { IGameState } from '../GameState/IGameState';
import { GameState } from '../GameState/GameState';
import { INPC } from '../GameState/INPC';
import { NPC } from '../GameState/NPC';
import { ICharacter } from '../GameState/ICharacter';
import { Character } from '../GameState/Character';
import { ILayer } from '../GameState/ILayer';
import { Layer } from '../GameState/Layer';
import { ITile } from '../GameState/ITile';
import { Tile } from '../GameState/Tile';
import { Position } from '../GameState/Position';
import { Chest } from '@/GameState/Chest';
import { ChestMimic } from '@/GameState/ChestMimic';
import { IInteractiveObject } from '@/GameState/IInteractiveObject';


const mapSize = 10;


export class ChangeHandler {
    public api: IApi;
    constructor(api: IApi) {
        this.api = api;
    }

    public getState() {
        return this.api.gameState().then((r) => {

            let data = r.data;

            return this.gameStateFromData(data);
        });
    }

    public move(direction: string) {
        return this.api.move(direction).then((r) => {

            let data = r.data;

            return this.gameStateFromData(data);

        });
    }

    public postUserInfo(username: string, password: string, email: string) {
        return this.api.postUserInfo(username, password, email).then((r) => {
            return r.data;
        });
    }

    public getUserInfo(username: string, password: string) {
        return this.api.getUserInfo(username, password).then((r) => {
            return r.data;
        });
    }

    private gameStateFromData(data: any): GameState {
        let tiles: any[][] = new Array();

        for (let j = 0; j < data.Tiles.length; j++) {
            tiles[j] = [];
            for (let k = 0; k < data.Tiles[j].length; k++) {

                if (data.Tiles[j][k] != null) {
                    tiles[j][k] = new Tile(data.Tiles[j][k].Walkable);
                } else {
                    tiles[j][k] = null;
                }
            }
        }

        let spawnPos: Position = new Position(data.InitialPlayerPosition.X, data.InitialPlayerPosition.Y);
        let exitPos: Position = new Position(data.ExitPosition.X, data.ExitPosition.Y);
        let interactiveObjects: Array<IInteractiveObject | null>[] = [];
        for (let i = 0; i < data.InteractiveObjects.length; i++) {
            let temp: Array<IInteractiveObject | null> = [];
            for (let j = 0; j < data.InteractiveObjects[i].length; j++) {
                if (data.InteractiveObjects[i][j] != null) {
                    if (data.InteractiveObjects[i][j].Name === 'Chest' ) {
                        temp.push(new Chest(data.InteractiveObjects[i][j].Name, data.InteractiveObjects[i][j].goldContent));
                    } else if (data.InteractiveObjects[i][j].Name === 'ChestMimic') {
                        temp.push(new ChestMimic(data.InteractiveObjects[i][j].Name, data.InteractiveObjects[i][j].discovered));
                    }
                } else {
                    temp.push(null);
                }
            }
            interactiveObjects.push(temp);
        }
        let layer: ILayer = new Layer(tiles, spawnPos, exitPos, interactiveObjects);

        let name: string = data.Player.Name;
        let xPosition: number = data.Player.Position.X;
        let yPosition: number = data.Player.Position.Y;
        let health: number = data.Player.Stats.CurrentHealth;
        let maxHealth: number = data.Player.Stats.MaxHealth;
        let gold: number = data.Player.Gold;
        let experience: number = data.Player.Experience;

        let player: ICharacter = new Character(name, xPosition, yPosition, health, maxHealth, gold, experience);

        let characters: any[][] = new Array();
        for (let l = 0; l < data.Characters.length; l++) {
            characters[l] = [];
            for (let m = 0; m < data.Characters[l].length; m++) {
                if (data.Characters[l][m] != null) {
                    let currentCharacter: any = data.Characters[l][m];
                    if (currentCharacter.hasOwnProperty('Gold')) {
                        characters[l][m] = player;
                    } else {
                        characters[l][m] = new NPC(new Position(currentCharacter.Position.x, currentCharacter.Position.Y));
                    }
                } else {
                    characters[l][m] = null;
                }
            }
        }


        let state = new GameState(characters, player, layer);

        return state;
    }
}
