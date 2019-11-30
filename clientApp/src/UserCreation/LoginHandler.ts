import { IApi } from './IApi';


export class LoginHandler {
    public api: IApi;
    constructor(api: IApi) {
        this.api = api;
    }

    public postUserInfo(username: string, password: string, email: string, color: string, sprite: string) {
        return this.api.postUserInfo(username, password, email, color, sprite).then((r) => {
            return r.data;
        });
    }

    public getUserInfo(username: string, password: string) {
        return this.api.getUserInfo(username, password).then((r) => {
            return r.data;
        });
    }
}
