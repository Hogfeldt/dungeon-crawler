<template>
</template>


<script lang="ts">
    // Import related to Vue
    import { Component, Prop, Vue } from 'vue-property-decorator';
    import { ChangeHandler } from '@/ChangeHandler/ChangeHandler';
    import { IApi } from '@/ChangeHandler/IApi';
    import { Api } from '@/ChangeHandler/API';
    import Phaser from 'phaser';
    import { MainGame } from '@/PhaserScenes/MainGame';

    let SERVER_PATH: string | undefined = process.env.VUE_APP_SERVER_PATH;
    if (SERVER_PATH === undefined) {
        // Default to server if environment variable is not set.
        SERVER_PATH = 'http://178.62.43.127:5000/';
    }

    const api: IApi = new Api(SERVER_PATH);
    const handler: ChangeHandler = new ChangeHandler(api);

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
        scale: {
            autoCenter: Phaser.Scale.CENTER_HORIZONTALLY,
        },
    };

    export default {
        props: {
            here: Boolean,
        },

        mounted() {
            const mainGameScene: MainGame = new MainGame(handler);

            const game: Phaser.Game = new Phaser.Game(config);
            game.scene.add('MainGame', mainGameScene, true);
        },
    };
</script>
