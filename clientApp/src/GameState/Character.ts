import { ICharacter } from './ICharacter';

export class Character implements ICharacter {
    public name: string;
    public xPos: number;
    public yPos: number;
    public health: number;
    public maxHealth: number;
    public gold: number;
    public experience: number;
    public damage: number;

    constructor(name: string,
                xpos: number,
                ypos: number,
                health: number,
                maxHealth: number,
                gold: number,
                experience: number,
                damage: number) {
        this.name   = name;
        this.xPos   = xpos;
        this.yPos   = ypos;
        this.health = health;
        this.maxHealth = maxHealth;
        this.gold = gold;
        this.experience = experience;
        this.damage = damage;
    }

    public inventoryList(): any { throw new Error('Not implemented'); }

    public item(): any { throw new Error('Not implemented'); }

    public printChar(): any { throw new Error('Not implemented'); }
}
