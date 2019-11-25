import { ITile } from "./ITile";
import { IPosition } from "./IPosition";
import { InteractiveObject } from './InteractiveObject';


export interface ILayer {
    getTile(x: number, y: number): ITile;
    getWidth(): number;
    getHeight(): number;
    getSpawn(): IPosition;
    getExit(): IPosition;
    getInteractiveObjects(): (InteractiveObject | null)[][]
}

