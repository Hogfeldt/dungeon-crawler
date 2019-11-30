import { IApi } from './IApi';
import { User } from './User';

export class LoginHandler {
    public api: IApi;
    constructor(api: IApi) {
        this.api = api;
    }

    public postUserInfo(user: User) {
        return this.api.postUserInfo(user).then((r) => {
            return r.data;
        });
    }

    public getUserInfo(user: User) {
        return this.api.getUserInfo(user).then((r) => {
            return r.data;
        });
    }
}
