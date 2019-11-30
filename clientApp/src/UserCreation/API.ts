import axios from 'axios';

import { IApi } from './IApi';
import { User } from './User'

export class Api implements IApi {
    private address: string;

    constructor(address: string) {
        this.address = address;
    }

    public postUserInfo(user: User): Promise<any> {
        return axios.post(this.address + '/api/UserInfoModels', { user });
    }

    public getUserInfo(user: User): Promise<any> {
        return axios({
            method: 'get',
            url: this.address + '/UserInfoModels',
            data: { user },
        });
    }
}
