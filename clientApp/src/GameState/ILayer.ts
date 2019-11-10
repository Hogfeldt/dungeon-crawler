import { ITile } from "./ITile"


export interface ILayer {
    getTile(x: number, y: number): ITile
}

