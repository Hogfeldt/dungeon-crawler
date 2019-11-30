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
    export default {
        name: 'App',

        components: {
            CharacterSelection,
            PhaserGame,
        },
        data() {
            return {
                CurrentComponent: "CharacterSelection",
                email: 'asd',
                username: 'das',
                password: 'asd',
            }
        },


        methods: {
            handleCharacterCreation() {
                // Do stuff with my color
                this.CurrentComponent = PhaserGame;
            },

            CreateNewUser(newEmail, newUsername, newPassword) {
                this.email = newEmail;
                this.password = newPassword;
                this.username = newUsername;

                this.CurrentComponent = CharacterSelection;
            },
        },


        computed: {
            currentProperties() {
                if (this.CurrentComponent === 'CharacterSelection') {
                    return {
                        username: this.username,
                        password: this.password,
                        email: this.email,
                    }
                }
            }
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
