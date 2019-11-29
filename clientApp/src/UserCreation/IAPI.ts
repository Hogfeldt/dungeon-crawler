export interface IApi {
    postUserInfo(username: string, password: string, email: string): Promise<any>;
    getUserInfo(username: string, password: string): Promise<any>;
}
