import { ITile } from './ITile';
import { IPosition } from './IPosition';
import { IInteractiveObject } from './IInteractiveObject';


export interface ILayer {
    getTile(x: number, y: number): ITile;
    getWidth(): number;
    getHeight(): number;
    getSpawn(): IPosition;
    getExit(): IPosition;
    getInteractiveObjects(): (IInteractiveObject | null)[][];
}


