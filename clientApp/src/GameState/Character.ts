import { ICharacter } from './ICharacter';

export class Character implements ICharacter {
    Name:   string;
    xPos:   number;
    yPos:   number;
    Health: number;
    
    constructor(name: string, xpos: number, ypos: number, health: number)
    {
        this.Name   = name;
        this.xPos   = xpos;
        this.yPos   = ypos;
        this.Health = health;
    }
}
