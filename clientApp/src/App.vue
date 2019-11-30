<template>
    <div id="app">
        <component v-on:CharacterCreated="handleCharacterCreation"
                   v-on:CreateNewUser="CreateNewUser"
                   v-bind="currentProperties"
                   v-bind:is="CurrentComponent" />

    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import CharacterSelection from './components/CharacterCreation.vue';
    import PhaserGame from './components/Phaser.vue';
    import SignIn from './components/SignIn.vue';


    import { LoginHandler } from '@/UserCreation/LoginHandler';
    import { IApiUser } from '@/UserCreation/IApi';
    import { ApiUser } from '@/UserCreation/API';


    const userApi: IApiUser = new ApiUser('http://178.62.43.127:5000/');
    const loginHandler: LoginHandler = new LoginHandler(userApi);


    export default {
        name: 'App',

        components: {
            CharacterSelection,
            PhaserGame,
            SignIn,
        },
        data() {
            return {
                CurrentComponent: 'SignIn',
                email: 'asd',
                username: 'das',
                password: 'asd',
            };
        },


        methods: {
            handleCharacterCreation() {
                // Do stuff with my color
                this.CurrentComponent = PhaserGame;
            },

            CreateNewUser(newEmail: string, newUsername: string, newPassword: string) {
                this.email = newEmail;
                this.password = newPassword;
                this.username = newUsername;

                this.CurrentComponent = CharacterSelection;
            },
        },


        computed: {
            currentProperties(): any {
                if (this.CurrentComponent === 'CharacterSelection') {
                    return {
                        username: this.username,
                        password: this.password,
                        email: this.email,
                        loginHandler,
                    };
                }
                if (this.CurrentComponent === 'SignIn') {
                    return { loginHandler };
                }
            },
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
