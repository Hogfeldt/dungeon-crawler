import axios from "axios";

import { IGameState } from "@/GameState/IGameState"
import { IApi } from "./IApi"


export default class Api implements  IApi{
    private address: string;

    constructor(address: string) {
        this.address = address;
    }

    public gameState() {
        return axios.get(this.address + "/gamestate");
    }

    public move(direction: string): Promise<any> {
        return axios.post(this.address + "/move",
            {
                Direction: direction
            });
    }
}