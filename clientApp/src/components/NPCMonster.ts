
import { INPC } from './INPC';


export class NPCMonster implements INPC {
    public Health: number;
    public Damage: number;

    public Name: string;
    public Type: string;
    public XPos: number;
    public YPos: number;

    constructor(health: number, damage: number, name: string, type: string, xPos: number, yPos: number) {
        this.Health = health;
        this.Damage = damage;
        this.Name   = name;
        this.Type   = type;
        this.XPos   = xPos;
        this.YPos   = yPos;
    }

    public printNPC() {
        console.log('Monsters name is ', this.Name, ' and are of type: ', this.Type);
        console.log('Monster has ', this.Health, ' health, and does ', this.Damage, ' damage');
        console.log('Monster position ', this.XPos, ',', this.YPos);
    }
}
