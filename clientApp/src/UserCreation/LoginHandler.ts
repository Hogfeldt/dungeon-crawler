import { IApi } from './IApi';


export class LoginHandler {
    public api: IApi;
    constructor(api: IApi) {
        this.api = api;
    }

    public postUserInfo(username: string, password: string, email: string) {
        return this.api.postUserInfo(username, password, email).then((r) => {
            return r.data;
        });
    }

    public getUserInfo(username: string, password: string) {
        return this.api.getUserInfo(username, password).then((r) => {
            return r.data;
        });
    }
}
