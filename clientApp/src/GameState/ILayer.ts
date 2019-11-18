import { ITile } from "./ITile";
import { IPosition } from "./IPosition";


export interface ILayer {
    getTile(x: number, y: number): ITile;
    getWidth(): number;
    getHeight(): number;
    getSpawn(): IPosition;
    getExit(): IPosition;
}

