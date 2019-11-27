<template>
    <div>
        <p>Phaser</p>
    </div>
</template>


<script lang="ts">
    // Import related to Vue
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import { ChangeHandler } from '@/ChangeHandler/ChangeHandler';
    import { IApi } from '@/ChangeHandler/IApi';
    import { Api } from '@/ChangeHandler/API';
    import { ILayer } from '@/GameState/ILayer';
    import { GameState } from '@/GameState/GameState';
    import { Character } from '@/GameState/Character';

    import Phaser from 'phaser';
    import { IInteractiveObject } from '../GameState/IInteractiveObject';
    import { Chest } from '@/GameState/Chest';
    import { ChestMimic } from '@/GameState/ChestMimic';



    const config: Phaser.Types.Core.GameConfig = {
        type: Phaser.AUTO,
        width: 800,
        height: 600,
        physics: {
            default: 'arcade',
            arcade: {
                gravity: { y: 0 },
                debug: false,
            },
        },
        scene: {
            preload,
            create,
            update,
        },
    };

    let SERVER_PATH: string | undefined = process.env.VUE_APP_SERVER_PATH;
    if (SERVER_PATH === undefined) {
        // Default to server if environment variable is not set.
        SERVER_PATH = 'http://178.62.43.127:5000/';
    }

    const api: IApi = new Api(SERVER_PATH);

    const handler: ChangeHandler = new ChangeHandler(api);
    let player: Phaser.GameObjects.Sprite;

    const tileWidth: number = 32;
    let tiles: Phaser.GameObjects.Group;
    let npcs: Phaser.GameObjects.Group;
    let interactiveObjects: Phaser.GameObjects.Group;
    let cursors: Phaser.Types.Input.Keyboard.CursorKeys;
    let healthText: Phaser.GameObjects.Text;
    let goldText: Phaser.GameObjects.Text;
    let experienceText: Phaser.GameObjects.Text;
    const game: Phaser.Game = new Phaser.Game(config);

    let up: boolean;
    let down: boolean;
    let right: boolean;
    let left: boolean;

    function preload(this: Phaser.Scene) {
        this.load.setBaseURL('https://oijfspafakporsfs-dungeon.fra1.digitaloceanspaces.com/');
        this.load.image('floor', 'floor.png');
        this.load.image('spawn', 'floor_entrance.png');
        this.load.image('exit', 'floor_ladder.png');
        this.load.image('wall', 'wall.png');
        this.load.image('chest', 'chest.png');
        this.load.image('chest_empty', 'chest_open.png');
        this.load.image('chest_mimic', 'chest_mimic.png');
        this.load.spritesheet('mob', 'mob.png', { frameWidth: 16, frameHeight: 20 });
        this.load.spritesheet('knight', 'knight.png', { frameWidth: 16, frameHeight: 28 });
    }

    function create(this: Phaser.Scene) {

        cursors = this.input.keyboard.createCursorKeys();
        tiles = this.add.group();
        npcs = this.add.group();
        interactiveObjects = this.add.group();

        game.anims.create({
            key: 'knight_idle',
            frames: game.anims.generateFrameNumbers('knight', { start: 0, end: 3 }),
            frameRate: 10,
            repeat: -1,
        });

        game.anims.create({
            key: 'mob_idle',
            frames: game.anims.generateFrameNumbers('mob', { start: 0, end: 3 }),
            frameRate: 10,
            repeat: -1,
        });

        handler.getState().then((r) => {
            drawFromState(r, this);
        });
    }

    function update(this: Phaser.Scene) {

        if (cursors.left!.isDown) {
            left = true;
        }

        if (left && cursors.left!.isUp) {
            left = false;
            handler.move('Left').then((r) => {
                cleanUp();
                drawFromState(r, this);
            });
        }

        if (cursors.right!.isDown) {
            right = true;
        }

        if (right && cursors.right!.isUp) {
            right = false;
            handler.move('Right').then((r) => {
                cleanUp();
                drawFromState(r, this);
            });
        }

        if (cursors.up!.isDown) {
            up = true;
        }

        if (up && cursors.up!.isUp) {
            up = false;
            handler.move('Up').then((r) => {
                cleanUp();
                drawFromState(r, this);
            });
        }

        if (cursors.down!.isDown) {
            down = true;
        }

        if (down && cursors.down!.isUp) {
            down = false;
            handler.move('Down').then((r) => {
                cleanUp();
                drawFromState(r, this);
            });
        }
    }

    function cleanUp() {
        npcs.clear();
        tiles.clear();
        interactiveObjects.clear();
        goldText.destroy();
        experienceText.destroy();
        healthText.destroy();
        destroySprite(player);
    }

    function destroySprite(sprite: Phaser.GameObjects.Sprite) {
        sprite.destroy();
    }

    function drawFromState(state: GameState, scene: Phaser.Scene) {

        const layer: ILayer = state.layerState;
        const characters: any[][] = state.NPCState;
        const playerState: Character = state.characterState;
        const interObjcs: (IInteractiveObject | null)[][] = layer.getInteractiveObjects();

        const xOff = 150;
        const yOff = 150;
        const playerYOff = 20;
        const mobYOff = 12;

        for (let i = 0; i < layer.getWidth(); i++) {
            for (let j = 0; j < layer.getHeight(); j++) {
                if (layer.getTile(i, j).walkable) {
                    tiles.create(i * tileWidth + xOff, j * tileWidth + yOff, 'floor').setScale(2);
                } else {
                    tiles.create(i * tileWidth + xOff, j * tileWidth + yOff, 'wall').setScale(2);
                }
            }
        }

        tiles.create(layer.getSpawn().x * tileWidth + xOff, layer.getSpawn().y  * tileWidth + yOff, 'spawn').setScale(2);
        tiles.create(layer.getExit().x * tileWidth + xOff, layer.getExit().y * tileWidth + yOff, 'exit').setScale(2);

        for (let i = 0; i < layer.getWidth(); i++) {
            for (let j = 0; j < layer.getHeight(); j++) {
                if (interObjcs[i][j] != null) {
                    if (interObjcs[i][j]!.name === 'Chest') {
                        const chest: Chest = interObjcs[i][j] as Chest;
                        if (chest.goldContent === 0) {
                            interactiveObjects.create(i * tileWidth + xOff, j * tileWidth + yOff, 'chest_empty')
                                .setScale(2);
                        } else {
                            interactiveObjects.create(i * tileWidth + xOff, j * tileWidth + yOff, 'chest')
                                .setScale(2);
                        }
                    } else if (interObjcs[i][j]!.name === 'ChestMimic') {
                        const chestmimic: ChestMimic = interObjcs[i][j] as ChestMimic;
                        if (chestmimic.discovered === false) {
                            interactiveObjects.create(i * tileWidth + xOff, j * tileWidth + yOff, 'chest')
                                .setScale(2);
                        } else {
                            interactiveObjects.create(i * tileWidth + xOff, j * tileWidth + yOff, 'chest_mimic')
                                .setScale(2);
                        }
                    }
                }
            }
        }


        for (let i = 0; i < layer.getWidth(); i++) {
            for (let j = 0; j < layer.getHeight(); j++) {
                const character = characters[i][j];
                if (character != null) {
                    if (character.constructor.name === 'Character') {
                        player = scene.add.sprite(i * tileWidth + xOff, j * tileWidth + yOff - playerYOff, 'knight');
                        player.setScale(2, 2);
                    } else if (character.constructor.name === 'NPC') {
                        const mob = scene.add.sprite(i * tileWidth + xOff, j * tileWidth + yOff - mobYOff, 'mob');
                        mob.setScale(2, 2);
                        mob.anims.play('mob_idle');
                        mob.flipX = true;
                        npcs.add(mob);
                    }
                }
            }
        }
        healthText = scene.add.text(16, 16,
            'Health: '
            + playerState.health
            + '/' + playerState.maxHealth,
            { fontSize: '20px' });

        goldText = scene.add.text(16, 45,
            'Gold: '
            + playerState.gold,
            { fontSize: '20px' });

        experienceText = scene.add.text(16, 74,
            'Experience: '
            + playerState.experience,
            { fontSize: '20px' });

        player.anims.play('knight_idle');
    }

    @Component
    export default class PhaserGame extends Vue {
    }
</script>
