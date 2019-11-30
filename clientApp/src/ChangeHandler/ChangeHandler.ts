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

            const data = r.data;

            return this.gameStateFromData(data);
        });
    }

    public move(direction: string) {
        return this.api.move(direction).then((r) => {

            const data = r.data;

            return this.gameStateFromData(data);

        });
    }

    private gameStateFromData(data: any): GameState {
        const tiles: any[][] = new Array();

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
        let spawnPos: Position | null = null;
        if (data.InitalPlayerPosition !== undefined) {
            spawnPos = new Position(data.InitialPlayerPosition.X, data.InitialPlayerPosition.Y);
        }

        let exitPos: Position | null = null;
        if (data.ExitPosition !== undefined) {
            exitPos = new Position(data.ExitPosition.X, data.ExitPosition.Y);
        }

        const interactiveObjects: any[][] = new Array();
        for (let i = 0; i < data.InteractiveObjects.length; i++) {
            interactiveObjects[i] = [];
            for (let j = 0; j < data.InteractiveObjects[i].length; j++) {
                if (data.InteractiveObjects[i][j] != null) {
                    const currentObject: any = data.InteractiveObjects[i][j];
                    if (data.InteractiveObjects[i][j].Name === 'Chest') {
                        interactiveObjects[i][j] = new Chest(
                            data.InteractiveObjects[i][j].Name,
                            data.InteractiveObjects[i][j].goldContent);
                    } else if (data.InteractiveObjects[i][j].Name === 'ChestMimic') {
                        interactiveObjects[i][j] = new ChestMimic(
                            data.InteractiveObjects[i][j].Name,
                            data.InteractiveObjects[i][j].discovered);
                    }
                } else {
                    interactiveObjects[i][j] = null;
                }
            }
        }

        const layer: ILayer = new Layer(tiles, spawnPos, exitPos, interactiveObjects);

        const name: string = data.Player.Name;
        const xPosition: number = data.Player.Position.X;
        const yPosition: number = data.Player.Position.Y;
        const health: number = data.Player.Stats.CurrentHealth;
        const maxHealth: number = data.Player.Stats.MaxHealth;
        const gold: number = data.Player.Gold;
        const experience: number = data.Player.Experience;
        const damage: number = data.Player.Stats.Damage;

        const player: ICharacter = new Character(
            name,
            xPosition,
            yPosition,
            health,
            maxHealth,
            gold,
            experience,
            damage);

        const characters: any[][] = new Array();
        for (let l = 0; l < data.Characters.length; l++) {
            characters[l] = [];
            for (let m = 0; m < data.Characters[l].length; m++) {
                if (data.Characters[l][m] != null) {
                    const currentCharacter: any = data.Characters[l][m];
                    if (currentCharacter.hasOwnProperty('Gold')) {
                        characters[l][m] = player;
                    } else {
                        characters[l][m] = new NPC(
                            new Position(currentCharacter.Position.x, currentCharacter.Position.Y),
                        );
                    }
                } else {
                    characters[l][m] = null;
                }
            }
        }


        const state = new GameState(characters, player, layer);

        return state;
    }
}
