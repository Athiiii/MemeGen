<template>
  <v-app id="inspire" :dark="darkmode">
    <app-navigation @navChanged="navigationChanged" :nav="nav"></app-navigation>
    <v-content>
      <transition name="fade" mode="out-in">
        <router-view></router-view>
      </transition>
    </v-content>
  </v-app>
</template>

<script>
import appSampleDisplay from "./appSampleDisplay";
import appNavigation from "./nav/appNavigation";
import store from "../store/index";

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
  },
  computed: {
    darkmode() {
      return store.state.darkmode;
    }
  }
};
</script>

<style>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
</style>
