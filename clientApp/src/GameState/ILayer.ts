import { ITile } from './ITile';
import { IPosition } from './IPosition';
import { IInteractiveObject } from './IInteractiveObject';
import { ICharacter } from './ICharacter';


export interface ILayer {
    getTile(x: number, y: number): ITile;
    getWidth(): number;
    getHeight(): number;
    getSpawn(): IPosition | null;
    getExit(): IPosition | null;
    getInteractiveObjects(): (IInteractiveObject | null)[][];
    getCharacters(): (ICharacter | null)[][];
}
