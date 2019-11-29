

export interface IApi {
    gameState(): Promise<any>;
    move(direction: string): Promise<any>;
}
