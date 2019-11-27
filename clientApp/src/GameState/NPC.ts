import { INPC } from './INPC';
import { IPosition } from './IPosition';

export class NPC implements INPC {

    public position: IPosition;

    constructor(position: IPosition) {
        this.position = position;
    }
}
