<template>
  <div>
    <v-toolbar app flat>
      <v-toolbar-side-icon @click="nav = !nav"/>
      <v-toolbar-title class="display-2 font-weight-light">Meme Creator</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn flat color="blue" large>
          <v-icon left large>create</v-icon>
          <span>Create Meme</span>
        </v-btn>
        <v-btn flat large>
          <v-icon left large>account_circle</v-icon>
          <span>Login</span>
        </v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <v-navigation-drawer app v-model="nav">
      <v-list>
        <v-list-tile v-for="link in links" :key="link.text" router :to="link.route">
          <v-list-tile-action>
            <v-icon>{{link.icon}}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title>{{link.text}}</v-list-tile-title>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>
  </div>
</template>

<script>
export default {
  data() {
    return {
      links: [
        { icon: "home", text: "Home", route: "/"},
        { icon: "folder", text: "Profile", route: "/profile" },
        { icon: "exit_to_app", text: "Logout", route: "/logout" }
      ],
      nav: false
    };
  }
};
</script>
