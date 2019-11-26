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
        scene: {
            preload: preload,
            create: create,
            update: update
        }
    };
    
    var api: IApi = new Api("http://178.62.43.127:5000");
    var handler: ChangeHandler = new ChangeHandler(api);
    var player;

    var tileWidth: number = 32;
    var tiles;
    var npcs;
    var cursors;
    var healthText;
    var goldText;
    var experienceText;
    var game = new Phaser.Game(config);

    var up;
    var down;
    var right;
    var left;

    function preload() {
        this.load.setBaseURL('https://oijfspafakporsfs-dungeon.fra1.digitaloceanspaces.com/')
        this.load.image('floor', 'floor.png');
        this.load.image('spawn', 'floor_entrance.png');
        this.load.image('exit', 'floor_ladder.png');
        this.load.image('wall', 'wall.png');
        this.load.spritesheet('mob', 'mob.png', { frameWidth: 16, frameHeight: 20 });
        this.load.spritesheet('knight', 'knight.png', { frameWidth: 16, frameHeight: 28 });
    }

    function create() {

        cursors = this.input.keyboard.createCursorKeys();
        tiles = this.add.group();
        npcs = this.add.group();

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
    }

    function cleanUp(game: any) {
        npcs.clear();
        tiles.clear();
        goldText.destroy();
        experienceText.destroy();
        healthText.destroy();
        destroySprite(player);
        
    }

    function destroySprite(sprite: any) {
        sprite.destroy();
    }

    function drawFromState(state: GameState, game: any) {

        var layer: ILayer = state._LayerState;
        var characters: any[][] = state._NPCState;
        var playerState: Character = state._CharacterState;

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