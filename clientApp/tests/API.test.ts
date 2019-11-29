import { Api } from '../src/ChangeHandler/Api';


import mockAxios from '../src/__mocks__/axios';

// This only works in js :(
// mockAxios.get.mock

let api: Api;


describe('Api', () => {
    beforeEach(() => {
        const address: string = '1234';
        api = new Api(address);
    });

    it('gets GameState', () => {

        // Arrange
        mockAxios.get.mockImplementationOnce(() => Promise.resolve({
            data: 'okok',
        }));

        // Act

        let res: any;
        api.gameState().then((result) => {
            console.log('data is ' + result.data);
            res = result.data;

            // Assert
            expect(res).toEqual('okok');
        });
    });
});
