import { IInteractiveObject } from './IInteractiveObject';

export class Chest implements IInteractiveObject {
    _name: string;
    goldContent: number;

    constructor(name: string, goldContent: number)
    {
        this._name  = name;
        this.goldContent = goldContent;
    }
}