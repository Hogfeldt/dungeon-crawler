import { IPlayer } from './IPlayer';
import { IPosition } from './IPosition';
import { Position } from './Position';

export class Player implements IPlayer {
    public name: string;
    public position: IPosition;
    public health: number;
    public maxHealth: number;
    public gold: number;
    public experience: number;
    public damage: number;

    constructor(name: string,
                xPos: number,
                yPos: number,
                health: number,
                maxHealth: number,
                gold: number,
                experience: number,
                damage: number) {
        this.name = name;
        this.position = new Position(xPos, yPos);
        this.health = health;
        this.maxHealth = maxHealth;
        this.gold = gold;
        this.experience = experience;
        this.damage = damage;
    }
}
