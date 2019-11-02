<template>
  <div class="hello">
      <h1>Hello</h1>
  </div>
</template>


<script lang="ts">
// Import related to Vue
import { Component, Prop, Vue } from 'vue-property-decorator';

// Imports phaser (not used in this example)
import 'phaser';

// Import Example classes
import { NPCMonster } from './NPCMonster';

// Some Exampel code
const Monster: NPCMonster = new NPCMonster(100, 50, 'BigDGlenn', 'Enemy', 0, 1);
Monster.printNPC();



// Exports the main 'program'
@Component
export default class Main extends Vue {
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
