<template>
    <div>
        <p>Game</p>
    </div>
</template>


<script>
    import { ChangeHandler } from "@/ChangeHandler/ChangeHandler"
    import { Api } from "@/ChangeHandler/API"
import { release } from 'os';

    export default {
        data() {
            return {
                state: Object,
                api: Object,
                handler: Object,
            }
        },
        mounted() {
            console.log("hej");

            this.api = new Api("https://localhost:44333/api");
            this.handler = new ChangeHandler(this.api);

            this.handler.getState().then(r => {
                console.log("hejlol");
                this.state = r;
            });

        }
    };
</script>


<style>

</style>