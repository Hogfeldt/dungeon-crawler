import axios from 'axios';

import { IApi } from './IApi';

export class Api implements  IApi {
    private address: string;

    constructor(address: string) {
        this.address = address;
    }

    public gameState(): Promise<any> {
        return axios.get(this.address + '/api/GameState', { withCredentials: true });
    }

    public move(direction: string): Promise<any> {
        return axios.post(this.address + '/api/move', direction, { withCredentials: true });
    }
}
