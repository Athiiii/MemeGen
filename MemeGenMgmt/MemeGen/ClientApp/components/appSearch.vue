<template>
  <v-content>
    <v-container fluid fill-height>
      <v-layout align-center justify-center>
        <v-flex xs12 sm8 md4>
          <v-card class="elevation-12">
            <v-input></v-input>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </v-content>
</template>

<script>
export default {
  data() {
    return {
      title: "Welcome to Your Vue.js App",
      login: '',
      password: ''
    };
  },
  methods: {
    alert() {
      alert(this.login + this.password);
    }
  }
};
</script>
