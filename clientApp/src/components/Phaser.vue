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
    import { Layer } from '@/GameState/Layer';
    import { ILayer } from '@/GameState/ILayer';
    import { Tile } from '@/GameState/Tile';
    import { ITile } from '@/GameState/ITile';
    import { GameState } from "@/GameState/GameState";
    import { Character } from "@/GameState/Character";
    import { IPosition } from "@/GameState/IPosition";

    import 'phaser';
import { stat } from 'fs';
import { InteractiveObject } from '../GameState/InteractiveObject';

class Demo extends Phaser.Scene {
    constructor() {
        super({
            key: 'Demo'
        })
    }

    preload() { 
        this.load.scenePlugin({
            key: 'rexuiplugin',
            url: 'https://raw.githubusercontent.com/rexrainbow/phaser3-rex-notes/master/plugins/dist/rexuiplugin.min.js',
            sceneKey: 'rexUI'
        });      
    }

    create() {
        var dialog = this.rexUI.add.dialog({
            x: 400,
            y: 300,

            background: this.rexUI.add.roundRectangle(0, 0, 100, 100, 20, 0x1565c0),

            title: this.rexUI.add.label({
                background: this.rexUI.add.roundRectangle(0, 0, 100, 40, 20, 0x003c8f),
                text: this.add.text(0, 0, 'Title', {
                    fontSize: '24px'
                }),
                space: {
                    left: 15,
                    right: 15,
                    top: 10,
                    bottom: 10
                }
            }),

            content: this.add.text(0, 0, 'Do you want to build a snow man?', {
                fontSize: '24px'
            }),

            actions: [
                createLabel(this, 'Yes'),
                createLabel(this, 'No')
            ],

            space: {
                title: 25,
                content: 25,
                action: 15,

                left: 20,
                right: 20,
                top: 20,
                bottom: 20,
            },

            align: {
                actions: 'right', // 'center'|'left'|'right'
            },

            expand: {
                content: false, // Content is a pure text object
            }
        })
            .layout()
            // .drawBounds(this.add.graphics(), 0xff0000)
            .popUp(1000);

        this.print = this.add.text(0, 0, '');
        dialog
            .on('button.click', function (button, groupName, index) {
                this.print.text += index + ': ' + button.text + '\n';
            }, this)
            .on('button.over', function (button, groupName, index) {
                button.getElement('background').setStrokeStyle(1, 0xffffff);
            })
            .on('button.out', function (button, groupName, index) {
                button.getElement('background').setStrokeStyle();
            });
    }

    update() { }
}

var createLabel = function (scene, text) {
    return scene.rexUI.add.label({
        // width: 40,
        // height: 40,

        background: scene.rexUI.add.roundRectangle(0, 0, 0, 0, 20, 0x5e92f3),

        text: scene.add.text(0, 0, text, {
            fontSize: '24px'
        }),

        space: {
            left: 10,
            right: 10,
            top: 10,
            bottom: 10
        }
    });
}

    var config = {
        type: Phaser.AUTO,
        width: 800,
        height: 600,
        physics: {
            default: 'arcade',
            arcade: {
                gravity: { y: 0 },
                debug: false
            }
        },
        scene: [{
            preload: preload,
            create: create,
            update: update
        }, Demo],
        "render.transparent": true
    };

    var api: IApi = new Api("https://localhost:5001");
    var handler: ChangeHandler = new ChangeHandler(api);
    var player;

    var tileWidth: number = 32;
    var tiles;
    var npcs;
    var interactiveObjects;
    var cursors;
    var healthText;
    var goldText;
    var experienceText;
    var game = new Phaser.Game(config);

    var up;
    var down;
    var right;
    var left;
    var space;

    function preload() {
        this.load.setBaseURL('https://oijfspafakporsfs-dungeon.fra1.digitaloceanspaces.com/')
        this.load.image('floor', 'floor.png');
        this.load.image('spawn', 'floor_entrance.png');
        this.load.image('exit', 'floor_ladder.png');
        this.load.image('wall', 'wall.png');
        this.load.image('chest', 'chest.png');
        this.load.image('chest_empty', "chest_open.png")
        this.load.spritesheet('mob', 'mob.png', { frameWidth: 16, frameHeight: 20 });
        this.load.spritesheet('knight', 'knight.png', { frameWidth: 16, frameHeight: 28 });
    }

    function create() {

        cursors = this.input.keyboard.createCursorKeys();
        tiles = this.add.group();
        npcs = this.add.group();
        interactiveObjects = this.add.group();

        game.anims.create({
            key: 'knight_idle',
            frames: game.anims.generateFrameNumbers('knight', { start: 0, end: 3 }),
            frameRate: 10,
            repeat: -1
        });

        game.anims.create({
            key: 'mob_idle',
            frames: game.anims.generateFrameNumbers('mob', { start: 0, end: 3 }),
            frameRate: 10,
            repeat: -1
        })

        //  A simple background for our game
        

        handler.getState().then(r => {
            drawFromState(r, this);
        })
    }

    function update() {

        if (cursors.left.isDown) {
            left = true;
        }

        if (left && cursors.left.isUp)
        {
            left = false;
            handler.move("Left").then(r => {
                cleanUp(this);
                drawFromState(r, this);
            })
        }

         if (cursors.right.isDown) {
            right = true;
        }

        if (right && cursors.right.isUp)
        {
            right = false;
            handler.move("Right").then(r => {
                cleanUp(this);
                drawFromState(r, this);
            })
        }

         if (cursors.up.isDown) {
            up = true;
        }

        if (up && cursors.up.isUp)
        {
            up = false;
            handler.move("Up").then(r => {
                cleanUp(this);
                drawFromState(r, this);
            })
        }

        if (cursors.down.isDown) {
            down = true;
        }

        if (down && cursors.down.isUp)
        {
            down = false;
            handler.move("Down").then(r => {
                cleanUp(this);
                drawFromState(r, this);
            })
        }
        if (cursors.space.isDown) {
            space = true;
        }
        if(space && cursors.space.isUp) {
            this.scene.start('Demo');
        }
    }

    function cleanUp(game: any) {
        npcs.clear();
        tiles.clear();
        goldText.destroy();
        experienceText.destroy();
        healthText.destroy();
        interactiveObjects.clear();
        destroySprite(player);
        
    }

    function destroySprite(sprite: any) {
        sprite.destroy();
    }

    function drawFromState(state: GameState, game: any) {

        var layer: ILayer = state._LayerState;
        var characters: any[][] = state._NPCState;
        var playerState: Character = state._CharacterState;
        var interObjcs: (InteractiveObject | null)[][] = layer.getInteractiveObjects();

        var xOff = 150;
        var yOff = 150;
        var playerYOff = 20;
        var mobYOff = 12;

        for (var i = 0; i < layer.getWidth(); i++) {
            for (var j = 0; j < layer.getHeight(); j++) {
                if (layer.getTile(i, j).walkable) {
                    tiles.create(i * tileWidth + xOff, j * tileWidth + yOff, 'floor').setScale(2);
                } else {
                    tiles.create(i * tileWidth + xOff, j * tileWidth + yOff, 'wall').setScale(2);
                }
            }
        }

        tiles.create(layer.getSpawn().x * tileWidth + xOff, layer.getSpawn().y  * tileWidth + yOff, 'spawn').setScale(2);
        tiles.create(layer.getExit().x * tileWidth + xOff, layer.getExit().y * tileWidth + yOff, 'exit').setScale(2);


        for (var i = 0; i < layer.getWidth(); i++) {
            for (var j = 0; j < layer.getHeight(); j++) {
                if (interObjcs[i][j] != null) {
                    if(interObjcs[i][j].goldContent == 0){
                        interactiveObjects.create(i * tileWidth + xOff, j * tileWidth + yOff, 'chest_empty').setScale(2);
                    } else{
                        interactiveObjects.create(i * tileWidth + xOff, j * tileWidth + yOff, 'chest').setScale(2);
                    }
                }
            }
        }


        for (var i = 0; i < layer.getWidth(); i++) {
            for (var j = 0; j < layer.getHeight(); j++) {
                var character = characters[i][j];
                if (character != null) {
                    if (character.constructor.name == "Character") {
                        player = game.add.sprite(i * tileWidth + xOff, j * tileWidth + yOff - playerYOff, 'knight').setScale(2, 2);
                    } else if (character.constructor.name == "NPC") {
                        var mob = game.add.sprite(i * tileWidth + xOff, j * tileWidth + yOff - mobYOff, 'mob').setScale(2, 2);
                        mob.anims.play('mob_idle');
                        mob.flipX = true;
                        npcs.add(mob);
                    }
                }
            }
        }
        healthText = game.add.text(16, 16, 'Health: ' + playerState.health + '/' + playerState.maxHealth, { fontSize: '20px' });
        goldText = game.add.text(16, 45, 'Gold: ' + playerState.gold, { fontSize: '20px' });
        experienceText = game.add.text(16, 74, 'Experience: ' + playerState.experience, { fontSize: '20px' });

        player.anims.play('knight_idle');
    }

    @Component
    export default class PhaserGame extends Vue {
    }
</script>