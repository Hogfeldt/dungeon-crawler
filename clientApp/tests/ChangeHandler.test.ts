import { ChangeHandler } from "../src/ChangeHandler/ChangeHandler"

import { IApi } from "../src/ChangeHandler/IApi"
import mockAPI from "../src/__mocks__/API"
jest.mock("../src/__mocks__/API");


var changeHandler: ChangeHandler;
var api: IApi;

describe("Api", () => {
    beforeEach(() => {
        var api: IApi = new mockAPI("");
        changeHandler = new ChangeHandler(api);
    });
    it("gets GameStateFromApi", () => {
        //Arrange
        
    });
});