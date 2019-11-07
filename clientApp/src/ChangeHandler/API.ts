import axios from "axios";


export default class API {
    private address: string;
    

    constructor(address: string) {
        this.address = address;
    }

    getGameState(): any {
        axios.get(this.address + "/state");
    }

    move(direction:string) {
        return this.postMovement(direction).then(response => {
            return response.data;
        });
    }

    private postMovement(direction: string) {
        return axios.post(this.address + "/move",
            {
                Direction: direction
            });
    }
}