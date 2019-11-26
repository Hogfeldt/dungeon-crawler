import { IInteractiveObject } from './IInteractiveObject';

export class Chest implements IInteractiveObject {
    public _name: string;
    public goldContent: number;

    constructor(name: string, goldContent: number) {
        this._name  = name;
        this.goldContent = goldContent;
    }
}
