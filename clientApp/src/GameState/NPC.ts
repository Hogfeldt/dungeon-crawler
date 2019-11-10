import { INPC } from "./INPC"

export class NPC implements INPC {
    constructor(xPosition: number, yPosition: number) {
        this.xPosition = xPosition;
        this.yPosition = yPosition;
    }

    xPosition: number;
    yPosition: number;
}