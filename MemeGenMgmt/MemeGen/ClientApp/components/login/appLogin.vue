<template>
  <v-layout justify-center align-center row fill-height class="ma-2">
    <v-flex xs12 sm8 md7 lg4>
      <v-card flat class="border-top-blue">
        <v-layout row fill-height justify-center wrap>
          <v-flex xs3 sm3 md3 lg3 class="text-xs-center">
            <v-icon size="100" class="mt-1">assignment_ind</v-icon>
            <span>
              <h3 class="headline">Sign in</h3>
            </span>
          </v-flex>
        </v-layout>
        <v-card-text>
          <v-text-field
            label="username or email"
            color="#0bafff"
            v-model="username"
            prepend-icon="perm_identity"
          ></v-text-field>
          <v-text-field
            label="password"
            color="#0bafff"
            v-model="password"
            prepend-icon="lock"
            :type="showPwd ? 'text' : 'password'"
            :append-icon="showPwd ? 'visibility' : 'visibility_off'"
            @click:append="showPwd = !showPwd"
          ></v-text-field>
          <h4 class="subheading grey--text text-lighten-4 mb-3">
            create a
            <a>
              <router-link to="/register" class="no-textdecoration">new account</router-link>
            </a>
          </h4>
          <v-btn color="info">Sign in</v-btn>
        </v-card-text>
      </v-card>
    </v-flex>
  </v-layout>
</template>

<script>
export default {
  data() {
    return {
      username: this.$store.state.mail,
      password: "",
      showPwd: false
    };
  },
  methods: {},
  components: {}
};
</script>

<style>
.border-top-blue {
  border-top: 3px solid #0bafff !important;
}

.no-textdecoration {
  text-decoration: none;
}
</style>
