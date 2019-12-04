import { User } from './User';

export interface IApiUser {
    postUserInfo(user: User): Promise<any>;
    getUserInfo(username: string, password: string): Promise<any>;
}
