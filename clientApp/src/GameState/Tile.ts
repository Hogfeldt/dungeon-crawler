import { ITile } from './ITile';

export class Tile implements ITile {
    public walkable: boolean;

    constructor(walkable: boolean) {
        this.walkable = walkable;
    }
}
