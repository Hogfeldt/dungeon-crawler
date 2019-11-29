import { ICharacter } from './ICharacter';

export class Character implements ICharacter {
    name:      string;
    xPos:      number;
    yPos:      number;
    health:    number;
    maxHealth: number;
    gold: number;
    experience: number;
    damage: number;
    
    constructor(name: string, xpos: number, ypos: number, health: number, maxHealth: number, gold: number, experience: number, damage: number)
    {
        this.name   = name;
        this.xPos   = xpos;
        this.yPos   = ypos;
        this.health = health;
        this.maxHealth = maxHealth;
        this.gold = gold;
        this.experience = experience;
        this.damage = damage;
    }

    inventoryList(): any { throw new Error("Not implemented"); }

    item(): any { throw new Error("Not implemented"); }

    printChar(): any { throw new Error("Not implemented"); }
}
