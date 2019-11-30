import { User } from './User';

export interface IApiUser {

    postUserInfo(user: User): Promise<any>;
    getUserInfo(user: User): Promise<any>;
}
