<template>
    <div id="app">
        <h1>Welcome to DungeonDash</h1>
        <router-view></router-view>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import VueRouter from 'vue-router';
    Vue.use(VueRouter);

    import SignIn from './components/SignIn.vue';
    import CharacterSelection from './components/CharacterCreation.vue';
    import Phaser from './components/Phaser.vue';

    import { LoginHandler } from '@/UserCreation/LoginHandler';
    import { IApiUser } from '@/UserCreation/IApi';
    import { ApiUser } from '@/UserCreation/API';

    const userApi: IApiUser = new ApiUser('http://dungeondash.me:5000/');
    const loginHandler: LoginHandler = new LoginHandler(userApi);
   

    const routes = [
        {
            name: 'login',
            path: '/',
            component: SignIn,
            props: true,
        },
        {
            name: 'character',
            path: '/CharacterSelection/:email/:username/:password',
            component: CharacterSelection,
            props: true,
        },
        {
            name: 'phaser',
            path: '/phaser',
            component: Phaser,
        },
    ];

    const router = new VueRouter({
        routes,
        mode: 'abstract',
    });


    export default {
        name: 'App',
        router,
    };

    router.replace('/');
</script>

<style>
    #app {
        font-family: 'Avenir', Helvetica, Arial, sans-serif;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
        text-align: center;
        color: #fff;
    }

    html, body {
        height: 100%;
        margin: 0;
        padding: 0;
        background-color: black;
    }

    canvas {
        margin: 0 auto;
    }
</style>
