import axios from 'axios';

import { IApi } from './IApi';

export class Api implements IApi {
    private address: string;

    constructor(address: string) {
        this.address = address;
    }

    public postUserInfo(username: string, password: string, email: string, color: string, sprite: string): Promise<any> {
        return axios.post(this.address + '/api/UserInfo', { UserName: username, Password: password, Email: email, Color: color, Sprite: sprite});
    }

    public getUserInfo(username: string, password: string): Promise<any> {
        return axios({
            method: 'get',
            url: this.address + '/api/UserInfo',
            data: { UserName: username, Password: password },
        });
    }
}
