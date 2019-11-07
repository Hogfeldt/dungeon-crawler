import { NPCMonster } from '../src/components/NPCMonster';

describe('Monster', () => {
    it('New Monster', () => {
        const monster = new NPCMonster(100, 50, 'BigDGlenn', 'Enemy', 0, 1);
        expect(monster.Name).toBe('BigDGlenn');
    });
    it('Monster Health', () => {
        const monster = new NPCMonster(100, 50, 'BigDGlenn', 'Enemy', 0, 1);
        expect(monster.Health).toBe(100);
    });
});
