import { IInteractiveObject } from './IInteractiveObject';

export class ChestMimic implements IInteractiveObject {
    public _name: string;
    public discovered: boolean;

    constructor(name: string, discovered: boolean) {
        this._name  = name;
        this.discovered = discovered;
    }
}
