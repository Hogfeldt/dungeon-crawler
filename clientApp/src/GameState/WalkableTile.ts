import { ITile } from "./ITile"

export class WalkableTile implements ITile {
    walkable: boolean = true;
    occupied: boolean = false;
}