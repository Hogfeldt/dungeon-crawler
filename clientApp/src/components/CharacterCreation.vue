<template>
    <article>
        <p>email: {{ email }}</p>
        <p>Username: {{ username }}</p>
        <p>Password: {{ password }}</p>
        <div class="container" :class="{'select-character-active' : changeCharacter}">
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-left">
                        <h2>You have chosen the Blue Knight</h2>
                        <p>You have chosen wisely</p>
                        <button class="invert" id="createBlue" @click="create('blue', 'knight')">Start Game</button>
                    </div>
                    <div class="overlay-right">
                        <h2>You have chosen the Red BooBoo</h2>
                        <p>You have chosen poorly</p>
                        <button class="invert" id="createRed" @click="create('red', 'booboo')">Start Game</button>
                    </div>
                </div>
            </div>
            <form class="change-to-red" action="#">
                <h2>To select the Red booboo click here</h2>
                <button @click="changeCharacter = !changeCharacter">Change Charater</button>
            </form>
            <form class="change-to-blue" action="#">
                <h2>To select the blue knight click here</h2>
                <button @click="changeCharacter = !changeCharacter">Change Charater</button>
            </form>
        </div>
    </article>
</template>

<script>

    export default {

        data: () => {
            return {
                changeCharacter: true,
            };
        },

        props: {
            username: String,
            email: String,
            password: String,
        },

        methods: {
            create(myColor, sprite) {
                // TODO: Send to server
                // handler.getUserInfo(this.username, this.password);
                if (myColor === 'red' || myColor === 'blue') {
                    //do stuff with color
                    handler.postUserInfo(this.username, this.password, this.email, myColor, sprite);
                    this.$emit('CharacterCreated');
                }
            },
        },
    };
</script>

<style lang="scss" scoped>
    .container {
        position: relative;
        width: 768px;
        height: 480px;
        border-radius: 10px;
        overflow: hidden;
        box-shadow: 0 15px 30px rgba(0, 0, 0, .2), 0 10px 10px rgba(0, 0, 0, .2);
        background: linear-gradient(to bottom, #efefef, #ccc);
        .overlay-container

    {
        position: absolute;
        top: 0;
        left: 50%;
        width: 50%;
        height: 100%;
        overflow: hidden;
        transition: transform .5s ease-in-out;
        z-index: 100;
    }

    .overlay {
        position: relative;
        left: -100%;
        height: 100%;
        width: 200%;
        color: #fff;
        transform: translateX(0);
        transition: transform .5s ease-in-out;
    }

    @mixin overlays($property) {
        position: absolute;
        top: 0;
        display: flex;
        align-items: center;
        justify-content: space-around;
        flex-direction: column;
        padding: 70px 40px;
        width: calc(50% - 80px);
        height: calc(100% - 140px);
        text-align: center;
        transform: translateX($property);
        transition: transform .5s ease-in-out;
    }

    .overlay-left {
        @include overlays(-20%);
        background: linear-gradient(to bottom right, #00e2ff, #000688);
    }

    .overlay-right {
        @include overlays(0);
        right: 0;
        background: linear-gradient(to bottom right, #ff0000, #6d0000);
    }

    }

    h2 {
        margin: 0;
    }

    p {
        margin: 20px 0 30px;
    }

    a {
        color: #222;
        text-decoration: none;
        margin: 15px 0;
        font-size: 1rem;
    }

    button {
        border-radius: 20px;
        border: 1px solid #009345;
        background-color: #009345;
        color: #fff;
        font-size: 1rem;
        font-weight: bold;
        padding: 10px 40px;
        letter-spacing: 1px;
        text-transform: uppercase;
        cursor: pointer;
        transition: transform .1s ease-in;
        &:active

    {
        transform: scale(.9);
    }

    &:focus {
        outline: none;
    }

    }

    button.invert {
        background-color: transparent;
        border-color: #fff;
    }

    form {
        position: absolute;
        top: 0;
        display: flex;
        align-items: center;
        justify-content: space-around;
        flex-direction: column;
        padding: 90px 60px;
        width: calc(50% - 120px);
        height: calc(100% - 180px);
        text-align: center;
        background: linear-gradient(to bottom, #efefef, #ccc);
        transition: all .5s ease-in-out;
        div

    {
        font-size: 1rem;
    }

    input {
        background-color: #eee;
        border: none;
        padding: 8px 15px;
        margin: 6px 0;
        width: calc(100% - 30px);
        border-radius: 15px;
        border-bottom: 1px solid #ddd;
        box-shadow: inset 0 1px 2px rgba(0, 0, 0, .4), 0 -1px 1px #fff, 0 1px 0 #fff;
        overflow: hidden;
        &:focus

    {
        outline: none;
        background-color: #fff;
    }

    }
    }

    .select-character-active {
        .change-to-blue

    {
        transform: translateX(100%);
    }

    .change-to-red {
        transform: translateX(100%);
        opacity: 1;
        z-index: 5;
        animation: show .5s;
    }

    .overlay-container {
        transform: translateX(-100%);
    }

    .overlay {
        transform: translateX(50%);
    }

    .overlay-left {
        transform: translateX(0);
    }

    .overlay-right {
        transform: translateX(20%);
    }

    }

    @keyframes show {
        0% {
            opacity: 0;
            z-index: 1;
        }

        49% {
            opacity: 0;
            z-index: 1;
        }

        50% {
            opacity: 1;
            z-index: 10;
        }
    }
</style>