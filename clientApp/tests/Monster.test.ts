import NPCMonster from '../src/components/NPCMonster';

describe('Monster', function() {
  it('New Monster', function() {
	  const Monster: NPCMonster = new NPCMonster(100, 50, 'BigDGlenn', 'Enemy', 0, 1);
	  expect(Monster.Name).toBe('BigDGlenn');
  });
 });