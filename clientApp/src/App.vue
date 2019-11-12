<template>
    <div>
        <Game></Game>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import Main from './components/Main.vue';
    import Game from './components/Game.vue';

    export default {
        name: "App",
        data() {

        },
        components: {
            Game
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
