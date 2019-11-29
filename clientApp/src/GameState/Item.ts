export class Item {
    public name: string;
    public type: string;
    public value: number;
    public damage: number;

    constructor(name: string, type: string, value: number, damage: number) {
        this.name  = name;
        this.type  = type;
        this.value = value;
        this.damage = damage;
    }

    public addDamage(damage: number) {
        this.damage = damage;
    }
}
