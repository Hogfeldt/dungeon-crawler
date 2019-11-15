<template>
    <div>
        <PhaserGame></PhaserGame>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Main from './components/Main.vue';
    import Game from './components/Game.vue';
    import PhaserGame from './components/Phaser.vue';

    export default {
        name: "App",
        data() {

        },
        components: {
            Main,
            Game,
            PhaserGame
        },
    };
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
