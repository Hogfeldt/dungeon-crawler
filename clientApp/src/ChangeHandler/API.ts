import axios from "axios";

import { IGameState } from "@/GameState/IGameState"
import { IApi } from "./IApi"


export class Api implements  IApi{
    private address: string;

    constructor(address: string) {
        this.address = address;
    }

    public gameState() {
        return axios.get(this.address + "/state");
    }

    public move(direction: string): Promise<any> {
        return axios.post(this.address + "/move",
            {
                Direction: direction
            });
    }
}