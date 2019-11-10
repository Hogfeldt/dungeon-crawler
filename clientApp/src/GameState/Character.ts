import { ICharacter } from './ICharacter';

export class Character implements ICharacter {
    name:   string;
    xPos:   number;
    yPos:   number;
    health: number;
    
    constructor(name: string, xpos: number, ypos: number, health: number)
    {
        this.name   = name;
        this.xPos   = xpos;
        this.yPos   = ypos;
        this.health = health;
    }

    inventoryList(): any { throw new Error("Not implemented"); }

    item(): any { throw new Error("Not implemented"); }

    printChar(): any { throw new Error("Not implemented"); }
}
