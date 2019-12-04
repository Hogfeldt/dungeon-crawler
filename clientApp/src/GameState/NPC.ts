import { ICharacter } from './ICharacter';
import { IPosition } from './IPosition';

export class NPC implements ICharacter {

    public position: IPosition;

    constructor(position: IPosition) {
        this.position = position;
    }
}
