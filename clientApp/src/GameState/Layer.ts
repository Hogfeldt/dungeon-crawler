import { ILayer } from "./ILayer";
import { ITile } from "./ITile";
import { IPosition } from "./IPosition";
import { InteractiveObject } from './InteractiveObject';

export class Layer implements ILayer {

    private tiles: ITile[][];
    private spawnPos: IPosition;
    private exitPos: IPosition;
    private interactiveObjects: (InteractiveObject | null)[][];


    constructor(tiles: ITile[][], spawnPos: IPosition, exitPos: IPosition, interactiveObjects: (InteractiveObject | null)[][]) {
        this.tiles = tiles;
        this.spawnPos = spawnPos;
        this.exitPos = exitPos;
        this.interactiveObjects = interactiveObjects;
    }
    getTile(x: number, y: number): ITile {
        return this.tiles[x][y];
    }

    getHeight(): number {
        return this.tiles[0].length;
    }

    getWidth(): number {
        return this.tiles.length;
    }

    getSpawn(): IPosition {
        return this.spawnPos;
    }

    getExit(): IPosition {
        return this.exitPos;
    }

    getInteractiveObjects(): (InteractiveObject | null)[][] {
        return this.interactiveObjects;
    }
}