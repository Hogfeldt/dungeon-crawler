import { IInteractiveObject } from './IInteractiveObject';

export class Chest implements IInteractiveObject {
    public name: string;
    public goldContent: number;

    constructor(name: string, goldContent: number) {
        this.name  = name;
        this.goldContent = goldContent;
    }
}
