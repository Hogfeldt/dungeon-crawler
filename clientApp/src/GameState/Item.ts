
export class Item {
    Name: string;
    Type: string;
    Value: number;
    Damage: number | undefined;

    constructor(name: string, type: string, value: number)
    {
        this.Name  = name;
        this.Type  = type;
        this.Value = value;
    }
    
    function AddDamage(damage: number)
    {
        this.Damage = damage;
    }
}
