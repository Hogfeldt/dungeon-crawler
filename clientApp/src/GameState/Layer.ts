import { ILayer } from "./ILayer"
import { ITile } from "./ITile";

export class Layer implements ILayer {

    private tiles: ITile[][];

    constructor(tiles: ITile[][]) {
        this.tiles = tiles;
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
}