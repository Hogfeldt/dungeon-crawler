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
    
    var api: IApi = new Api("https://localhost:44333");
    var handler: ChangeHandler = new ChangeHandler(api);
    var gameState: GameState;
    var player;

    var tileWidth: number = 32;
    var tiles;
    var npcs;
    var game = new Phaser.Game(config);

    function preload() {
        this.load.setBaseURL('https://oijfspafakporsfs-dungeon.fra1.digitaloceanspaces.com/')
        this.load.image('floor', 'floor.png');
        this.load.image('wall', 'wall.png');
        this.load.image('mob', 'mob.png');
        this.load.spritesheet('knight', 'knight.png', { frameWidth: 16, frameHeight: 28 });
    }

    function create() {

        tiles = this.add.group();
        npcs = this.add.group();

        //  A simple background for our game

        handler.getState().then(r => {
            drawFromState(r, this);
        })

        //var tileValues = [[true, true, false, false, false, false, false, false, false, true],
        //[true, true, false, false, false, false, false, false, false, false],
        //[true, true, false, false, false, false, false, false, false, false],
        //[true, true, true, true, true, false, false, false, false, false],
        //[false, false, false, false, true, false, false, false, false, false],
        //[false, false, false, false, true, false, false, false, false, false],
        //[false, false, false, false, true, false, false, false, false, false],
        //[false, false, false, false, true, true, true, false, false, false],
        //[false, false, false, false, true, true, true, false, false, false],
        //[false, false, false, false, true, true, true, false, false, false]];

        //var width = tileValues.length;
        //var height = tileValues[0].length;
        //var xOff = 100;
        //var yOff = 100;

        //for (var i = 0; i < width; i++) {
        //    for (var j = 0; j < height; j++) {
        //        if (tileValues[i][j]) {
        //            tiles.create(i * tileWidth + xOff, j * tileWidth + yOff, 'floor').setScale(2);
        //        } else {
        //            tiles.create(i * tileWidth + xOff, j * tileWidth + yOff, 'wall').setScale(2);
        //        }
        //    }
        //}

        //player = this.add.sprite(100, 100, 'knight');
        //player.setScale(2, 2);


        //this.anims.create({
        //    key: 'knight_idle',
        //    frames: this.anims.generateFrameNumbers('knight', { start: 0, end: 3 }),
        //    frameRate: 10,
        //    repeat: -1
        //});


        //player.anims.play('knight_idle');

    }

    function drawFromState(state: GameState, game: any) {

        console.log(state);

        var layer: ILayer = state._LayerState;
        var characters: any[][] = state._NPCState;
        var playerState: Character = state._CharacterState;

        var xOff = 100;
        var yOff = 100;
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

        for (var i = 0; i < layer.getWidth(); i++) {
            for (var j = 0; j < layer.getHeight(); j++) {
                var character = characters[i][j];
                if (character != null) {
                    console.log(character.constructor.name);
                    if (character.constructor.name == "Character") {
                        player = game.add.sprite(i * tileWidth + xOff, j * tileWidth + yOff - playerYOff, 'knight').setScale(2, 2);
                    } else if (character.constructor.name == "NPC") {
                        npcs.create(i * tileWidth + xOff, j * tileWidth + yOff - mobYOff, 'mob').setScale(2, 2);
                    }
                }
            }
        }

        game.anims.create({
            key: 'knight_idle',
            frames: game.anims.generateFrameNumbers('knight', { start: 0, end: 3 }),
            frameRate: 10,
            repeat: -1
        });

        player.anims.play('knight_idle');
    }

    function update() {
    }

    @Component
    export default class PhaserGame extends Vue {
    }
</script>