<template>
  <v-app id="inspire">
    <app-navigation @navChanged="navigationChanged" :nav="nav"></app-navigation>
    <v-content>
        <router-view></router-view>
    </v-content>
  </v-app>
</template>

<script>
import appSampleDisplay from "./appSampleDisplay";
import appNavigation from "./nav/appNavigation";

export default {
  data() {
    return {
      nav: false
    };
  },
  components: {
    appSampleDisplay,
    appNavigation
  },
  methods: {
    navigationChanged(event) {
      this.nav = event;
    }
  }
};
</script>
