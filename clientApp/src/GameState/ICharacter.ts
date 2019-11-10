

export interface ICharacter {
    name: string;
    xPos: number;
    yPos: number;
    health: number;

    inventoryList(): any;
    item(): any;
    printChar(): any;
}

