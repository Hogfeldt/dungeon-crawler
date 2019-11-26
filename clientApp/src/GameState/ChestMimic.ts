import { IInteractiveObject } from './IInteractiveObject';

export class ChestMimic implements IInteractiveObject {
    _name: string;
    discovered: boolean;

    constructor(name: string, discovered: boolean)
    {
        this._name  = name;
        this.discovered = discovered;
    }
}