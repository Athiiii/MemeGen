<template>
  <div>
    <v-toolbar app flat wrap>
      <v-toolbar-side-icon @click="nav = !nav"/>
      <router-link to="/" tag="v-toolbar-title">
        <v-toolbar-title class="display-2 font-weight-light">Meme Creator</v-toolbar-title>
      </router-link>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <v-btn flat color="blue" v-on="on" to="/create" large>
              <v-icon left large>create</v-icon>
              <span class="hidden-xs-only">Create Meme</span>
            </v-btn>
          </template>
          <span>Create your custom Meme</span>
        </v-tooltip>
        <v-btn to="/login" flat large>
          <v-icon left large>account_circle</v-icon>
          <span class="hidden-xs-only">Login</span>
        </v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <v-navigation-drawer app v-model="nav">
      <v-list>
        <v-list-tile v-for="link in topLinks" :key="link.text" router :to="link.route">
          <v-list-tile-action>
            <v-icon>{{link.icon}}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title>{{link.text}}</v-list-tile-title>
        </v-list-tile>
        <v-list-tile>
          <v-list-tile-action>
            <v-list-tile-title>
              <v-layout row justify-space-between wrap>
                <v-flex>
                  <v-switch v-model="darkmode" slot="default">
                    <template v-slot:label>Darkmode</template>
                  </v-switch>
                </v-flex>
                <v-flex>
                  <v-chip color="orange" text-color="white" class="mt-0 ml-3" small>Beta</v-chip>
                </v-flex>
              </v-layout>
            </v-list-tile-title>
          </v-list-tile-action>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
  </div>
</template>

<script>
import store from "../../store/index";

export default {
  data() {
    return {
      topLinks: [
        { icon: "home", text: "Home", route: "/" },
        { icon: "account_box", text: "Profile", route: "/profile" },
        { icon: "exit_to_app", text: "Logout", route: "/logout" },
        { icon: "code", text: "API", route: "/developer/api" }
      ],
      nav: false
    };
  },
  computed: {
    darkmode: {
      get() {
        return store.state.darkmode;
      },
      set() {
        store.commit("switchDarkmode");
      }
    }
  }
};
</script>
