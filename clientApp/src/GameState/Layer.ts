import { ILayer } from './ILayer';
import { ITile } from './ITile';
import { IPosition } from './IPosition';
import { IInteractiveObject } from './IInteractiveObject';

export class Layer implements ILayer {

    private tiles: ITile[][];
    private spawnPos: IPosition | null;
    private exitPos: IPosition| null;
    private interactiveObjects: (IInteractiveObject | null)[][];


    constructor(tiles: ITile[][],
                spawnPos: IPosition | null,
                exitPos: IPosition | null,
                interactiveObjects: (IInteractiveObject | null)[][]) {
        this.tiles = tiles;
        this.spawnPos = spawnPos;
        this.exitPos = exitPos;
        this.interactiveObjects = interactiveObjects;
    }
    public getTile(x: number, y: number): ITile {
        return this.tiles[x][y];
    }

    public getHeight(): number {
        return this.tiles[0].length;
    }

    public getWidth(): number {
        return this.tiles.length;
    }

    public getSpawn(): IPosition | null {
        return this.spawnPos;
    }

    public getExit(): IPosition | null {
        return this.exitPos;
    }

    public getInteractiveObjects(): (IInteractiveObject | null)[][] {
        return this.interactiveObjects;
    }
}
