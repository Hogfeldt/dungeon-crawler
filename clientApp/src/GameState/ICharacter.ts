export interface Icharacter {
    Name: string;
    xPos: number;
    yPos: number;
    Health: number;

    inventoryList(): any;
    item(): any;
    printChar(): any;
}
