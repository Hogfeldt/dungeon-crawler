

export interface IApi {
    gameState(): Promise<any>;
    move(direction: string): Promise<any>;
    postUserInfo(username: string, password: string, email: string): Promise<any>;
    getUserInfo(username: string, password: string): Promise<any>;
}
