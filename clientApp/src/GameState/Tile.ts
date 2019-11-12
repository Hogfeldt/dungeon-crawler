import { ITile } from "./ITile"

export class Tile implements ITile {
    walkable: boolean;

    constructor(walkable: boolean) {
        this.walkable = walkable;
    }
}