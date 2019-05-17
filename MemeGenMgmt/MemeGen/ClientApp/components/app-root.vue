<template>
  <v-app id="inspire" :dark="darkmode">
    <app-navigation></app-navigation>
    <app-search></app-search>
    <v-layout align-center>
      <v-flex lg3>
        <v-btn @click="darkmode = !darkmode">Activate Dark mode</v-btn>
      </v-flex>
    </v-layout>
  </v-app>
</template>

<script>
import appSearch from "./appSearch";
import appNavigation from "./appNavigation";

export default {
  data() {
    return {
      darkmode: false
    };
  },
  components: {
    appSearch,
    appNavigation
  }
};
</script>
