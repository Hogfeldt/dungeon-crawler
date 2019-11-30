export interface ICharacter {
    name: string;
    xPos: number;
    yPos: number;
    health: number;
    maxHealth: number;
    gold: number;
    experience: number;
    damage: number;

    inventoryList(): any;
    item(): any;
    printChar(): any;
}

