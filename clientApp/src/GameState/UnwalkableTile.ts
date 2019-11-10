import { ITile } from "./ITile"

export class UnwalkableTile implements ITile {
    walkable: boolean = false;
    occupied: boolean = false;
}