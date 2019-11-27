import { ChangeHandler } from '../src/ChangeHandler/ChangeHandler';
import { IApi } from '../src/ChangeHandler/IApi';
import mockAPI from '../src/__mocks__/API';
jest.mock('../src/__mocks__/API');
import 'jest';

describe('Api', () => {
    beforeEach(() => {
        const api: IApi = new mockAPI('');
        const changeHandler: ChangeHandler = new ChangeHandler(api);
    });
    it('gets GameStateFromApi', () => {
        expect(true).toEqual(true);
    });
});
