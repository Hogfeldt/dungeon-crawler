import axios from 'axios';

import { IApiUser } from './IApi';
import { User } from './User';

export class ApiUser implements IApiUser {
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
