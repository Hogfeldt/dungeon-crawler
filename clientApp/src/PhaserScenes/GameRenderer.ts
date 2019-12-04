import Phaser from 'phaser';
import { ILayer } from '../GameState/ILayer';
import { ICharacter } from '../GameState/ICharacter';
import { IInteractiveObject } from '../GameState/IInteractiveObject';
import { Chest } from '../GameState/Chest';
import { ChestMimic } from '../GameState/ChestMimic';
import { IPosition } from '../GameState/IPosition';

export class GameRenderer {
    private static imgWidth = 16;

    private xOff: number = 150;
    private yOff: number = 150;
    private playerYOff: number = -20;
    private mobYOff: number = -12;
    private scale: number = 2;
    private tileWidth: number = 2 * GameRenderer.imgWidth;
    private scene: Phaser.Scene;

    constructor(scene: Phaser.Scene, scale?: number) {
        this.scene = scene;

        if (scale !== undefined) {
            this.scale = scale;
            this.tileWidth = this.scale * GameRenderer.imgWidth;
            this.playerYOff = this.scale * -10;
            this.mobYOff = this.scale * -6;
        }
    }

    public setScale(scale: number) {
        this.scale = scale;
        this.tileWidth = this.scale * GameRenderer.imgWidth;
    }

    public renderLayer(layer: ILayer): Phaser.GameObjects.Group {
        const tiles = this.scene.add.group();
        // Generate dungeon layout
        for (let i = 0; i < layer.getWidth(); i++) {
            for (let j = 0; j < layer.getHeight(); j++) {
                const x = i * this.tileWidth + this.xOff;
                const y = j * this.tileWidth + this.yOff;
                if (layer.getTile(i, j).walkable) {
                    tiles.create(x, y, 'floor').setScale(this.scale);
                } else {
                    tiles.create(x, y, 'wall').setScale(this.scale);
                }
            }
        }

        // Find spawn and exit
        const spawn: IPosition | null = layer.getSpawn();
        const exit: IPosition | null = layer.getExit();

        // If spawn and exit exist, create them.
        if (spawn != null) {
            tiles.create(
                spawn.x * this.tileWidth + this.xOff,
                spawn.y * this.tileWidth + this.yOff,
                'spawn')
                .setScale(this.scale);
        }
        if (exit != null) {
            tiles.create(
                exit.x * this.tileWidth + this.xOff,
                exit.y * this.tileWidth + this.yOff,
                'exit')
                .setScale(this.scale);
        }

        return tiles;
    }

    public renderInteractiveObjects(interObjects: (IInteractiveObject | null)[][]): Phaser.GameObjects.Group {
        const objects = this.scene.add.group();
        // Loop over interObjects to find any objects on the layer
        for (let i = 0; i < interObjects.length; i++) {
            for (let j = 0; j < interObjects[0].length; j++) {
                if (interObjects[i][j] != null) {
                    // Object found, create it at appropriate x, y position.
                    const x = i * this.tileWidth + this.xOff;
                    const y = j * this.tileWidth + this.xOff;

                    objects.add(this.renderObject(interObjects[i][j] as IInteractiveObject, x, y), true);
                }
            }
        }

        return objects;
    }

    public renderObject(object: IInteractiveObject, x: number, y: number): Phaser.GameObjects.Sprite {
        switch (object.name) {
            case 'Chest':
                return this.renderChest(object as Chest, x, y);
            case 'ChestMimic':
                return this.renderChestMimic(object as ChestMimic, x, y);
            default:
                throw new Error('Object with unhandled name exists in InteractiveObjects');
        }
    }

    public renderChest(chest: Chest, x: number, y: number): Phaser.GameObjects.Sprite {
        if (chest.goldContent === 0) {
            return new Phaser.GameObjects.Sprite(this.scene, x, y, 'chest_empty').setScale(this.scale);
        } else {
            return new Phaser.GameObjects.Sprite(this.scene, x, y, 'chest').setScale(this.scale);
        }
    }

    public renderChestMimic(chestMimic: ChestMimic, x: number, y: number): Phaser.GameObjects.Sprite {
        if (chestMimic.discovered) {
            return new Phaser.GameObjects.Sprite(this.scene, x, y, 'chest_mimic').setScale(this.scale);
        } else {
            return new Phaser.GameObjects.Sprite(this.scene, x, y, 'chest').setScale(this.scale);
        }
    }

    public renderCharacters(characters: (ICharacter | null)[][]): Phaser.GameObjects.Group {
        const npcs = new Phaser.GameObjects.Group(this.scene);

        // Iterate through character array to find any characters to render
        for (let i = 0; i < characters.length; i++) {
            for (let j = 0; j < characters[0].length; j++) {
                const character = characters[i][j];
                if (character != null) {
                    // Character found, render it at appropriate x, y position.
                    const x = i * this.tileWidth + this.xOff;
                    const y = j * this.tileWidth + this.yOff;

                    npcs.add(this.renderCharacter(character, x, y), true);
                }
            }
        }

        return npcs;
    }

    public renderCharacter(character: ICharacter, x: number, y: number): Phaser.GameObjects.Sprite {
        switch (character.constructor.name) {
        case 'Player':
            return this.renderPlayer(x, y + this.playerYOff);
        case 'NPC':
            return this.renderNPC(x, y + this.mobYOff);
        default:
            throw new Error('Object with unhandled name exists in InteractiveObjects');
        }
    }

    public renderPlayer(x: number, y: number): Phaser.GameObjects.Sprite {
        const player = new Phaser.GameObjects.Sprite(this.scene, x, y, 'knight');
        player.setScale(this.scale);
        player.anims.play('knight_idle');
        return player;
    }

    public renderNPC(x: number, y: number): Phaser.GameObjects.Sprite {
        const npc = new Phaser.GameObjects.Sprite(this.scene, x, y, 'mob');
        npc.setScale(this.scale);
        npc.anims.play('mob_idle');
        npc.flipX = true;
        return npc;
    }

    public updateHealth(healthText: Phaser.GameObjects.Text, currentHealth: number, maxHealth: number) {
        healthText.setText('Health: ' + currentHealth + '/' + maxHealth);
    }

    public updateGold(goldText: Phaser.GameObjects.Text, gold: number) {
        goldText.setText('Gold: ' + gold);
    }

    public updateExperience(experienceText: Phaser.GameObjects.Text, experience: number) {
        experienceText.setText('Experience: ' + experience);
    }

    public updateDamage(damageText: Phaser.GameObjects.Text, damage: number) {
        damageText.setText('Damage: ' + damage);
    }
}
