<template>
  <v-text :config="textConfig"/>
</template>
<script>
var width = window.innerWidth;
var height = window.innerHeight;

export default {
  data() {
    return {
      textConfig: {
        text: "Hello",
        x: 50,
        y: 80,
        fontSize: 20,
        draggable: true,
        width: 200
      }
    };
  },
  methods: {
    run() {}
  }
};
</script>

<style>
body {
  margin: 0;
  padding: 0;
  overflow: hidden;
  background-color: #f0f0f0;
}
</style>