import { IPosition } from "./IPosition";

export class Position implements IPosition {
    public x: number;
    public y: number;

    constructor(x: number, y: number) {
        this.x = x;
        this.y = y;
    }

    getX(): number { return this.x }

    getY(): number { return this.y }
}