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

    public postUserInfo(username: string, password: string, email: string): Promise<any> {
        return axios.post(this.address + '/api/UserInfo', { UserName: username, Password: password, Email: email });
    }

    public getUserInfo(username: string, password: string): Promise<any> {
        return axios({
            method: 'get',
            url: this.address + '/api/UserInfo',
            data: { UserName: username, Password: password },
        });
    }
}
