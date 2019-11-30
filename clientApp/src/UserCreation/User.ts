import { Character } from './Character';

export class  User {
    public username: string;
    public password: string;
    public email: string;
    public character: Character;

    constructor(username: string, password: string, email: string, character: Character) {
        this.username = username;
        this.password = password;
        this.email = email;
        this.character = character;
    }
}
