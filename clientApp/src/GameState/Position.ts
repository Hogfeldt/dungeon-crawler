import { IPosition } from "./IPosition";

export class Position implements IPosition {
    xPos: number;
    yPos: number;

    constructor(xPos: number, yPos: number) {
        this.xPos = xPos;
        this.yPos = yPos;
    }
}