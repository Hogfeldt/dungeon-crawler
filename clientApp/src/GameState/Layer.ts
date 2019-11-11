import { ILayer } from "./ILayer"
import { ITile } from "./ITile";

export class Layer implements ILayer {
    getTile(x: number, y: number): ITile {
         throw new Error("Not implemented");
    }
}