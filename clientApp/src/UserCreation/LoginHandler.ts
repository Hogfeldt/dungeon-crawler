
import { IApiUser } from './IApi';
import { User } from './User';

export class LoginHandler {
    public api: IApiUser;
    constructor(api: IApiUser) {
        this.api = api;
    }


    public postUserInfo(user: User) {
        return this.api.postUserInfo(user).then((r) => {
            return r.data;
        });
    }

    public getUserInfo(username: string, password: string) {
        return this.api.getUserInfo(username, password).then((r) => {
            return r.data;
        });
    }
}
