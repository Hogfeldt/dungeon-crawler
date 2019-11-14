
export class Item {
    name: string;
    type: string;
    value: number;
    damage: number;

    constructor(name: string, type: string, value: number, damage: number)
    {
        this.name  = name;
        this.type  = type;
        this.value = value;
        this.damage = damage;
    }
    
    public addDamage(damage: number)
    {
        this.damage = damage;
    }
}
