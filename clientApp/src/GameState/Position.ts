import { IPosition } from './IPosition';

export class Position implements IPosition {
    public x: number;
    public y: number;

    constructor(x: number, y: number) {
        this.x = x;
        this.y = y;
    }

    public getX(): number { return this.x; }

    public getY(): number { return this.y; }
}
