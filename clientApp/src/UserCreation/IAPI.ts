import { User } from './User';

export interface IApi {
    postUserInfo(user: User): Promise<any>;
    getUserInfo(user: User): Promise<any>;
}
