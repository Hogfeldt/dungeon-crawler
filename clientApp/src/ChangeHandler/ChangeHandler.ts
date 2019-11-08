import API from './API';

export class ChangeHandler {
    api: API;
    constructor(api:API) {
        this.api = api;
    }

    move(direction: string) {
        return this.api.move(direction);
    }
}