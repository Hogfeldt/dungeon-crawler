import { ICharacter } from './ICharacter';

export interface IPlayer extends ICharacter {
    name: string;
    health: number;
    maxHealth: number;
    gold: number;
    experience: number;
    damage: number;
}
