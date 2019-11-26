import { IApi } from "@/ChangeHandler/IApi";

export default class Api implements IApi {


    gameState(): Promise<any> { throw new Error("Not implemented"); }
    move(direction: string): Promise<any> { throw new Error("Not implemented"); }
    postUserInfo(username: string, password: string, email: string): Promise<any> { throw new Error("Not implemented") }
    getUserInfo(username: string, password: string): Promise<any> { throw new Error("Not implemented"); }
    private address: string;

    constructor(address: string) {
        this.address = address;
    }
}