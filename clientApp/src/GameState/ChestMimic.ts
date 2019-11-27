import { IInteractiveObject } from './IInteractiveObject';

export class ChestMimic implements IInteractiveObject {
    public name: string;
    public discovered: boolean;

    constructor(name: string, discovered: boolean) {
        this.name  = name;
        this.discovered = discovered;
    }
}
