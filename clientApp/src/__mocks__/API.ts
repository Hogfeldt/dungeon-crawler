import { IApi } from '@/ChangeHandler/IApi';

export default class Api implements IApi {

    private address: string;

    constructor(address: string) {
        this.address = address;
    }

    public gameState(): Promise<any> { throw new Error('Not implemented'); }
    public move(direction: string): Promise<any> { throw new Error('Not implemented'); }
    public postUserInfo(username: string, password: string, email: string): Promise<any> { throw new Error('Not implemented'); }
    public getUserInfo(username: string, password: string): Promise<any> { throw new Error('Not implemented'); }
}
