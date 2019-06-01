<template>
  <v-layout justify-center align-center row fill-height class="ma-2">
    <v-flex xs12 sm8 md7 lg4>
      <v-form ref="form">
        <v-card flat class="border-top-blue">
          <v-layout row fill-height justify-center wrap>
            <v-flex xs3 sm3 md3 lg3 class="text-xs-center">
              <v-icon size="100" class="mt-1">assignment_ind</v-icon>
              <span>
                <h3 class="headline">Register</h3>
              </span>
            </v-flex>
          </v-layout>
          <v-card-text>
            <v-text-field
              label="E-Mail"
              color="#0bafff"
              v-model="mail"
              prepend-icon="email"
              hint="We won't spam you"
              :rules="mailRule"
            ></v-text-field>
            <v-text-field
              label="username"
              color="#0bafff"
              v-model="username"
              prepend-icon="perm_identity"
              :rules="usernameRule"
            ></v-text-field>
            <v-text-field
              label="password"
              color="#0bafff"
              v-model="password"
              prepend-icon="lock"
              :type="showPwd ? 'text' : 'password'"
              :append-icon="showPwd ? 'visibility' : 'visibility_off'"
              :rules="passwordRule"
              @click:append="showPwd = !showPwd"
              hint="At least 8 characters"
            ></v-text-field>
            <v-checkbox v-model="agb" color="#0bafff" :rules="agbRule">
              <label slot="label">
                Yes, I have read and accepted the
                <a
                  @click="displayModal('Terms of Use', 'terms')"
                >Terms of Use</a> and
                <a @click="displayModal('Privacy Policy', 'privacy')">Privacy Policy</a>
                <app-modal :dialog="modal.dialog" :content="modal.content" :title="modal.title"></app-modal>
              </label>
            </v-checkbox>
            <v-btn color="info" @click="submit">Register</v-btn>
          </v-card-text>
        </v-card>
      </v-form>
    </v-flex>
  </v-layout>
</template>

<script>
import appModal from "../appModal";
import store from "../../store";

export default {
  data() {
    return {
      mail: "",
      username: "",
      password: "",
      agb: false,
      showPwd: false,
      modal: {
        title: "",
        content: "",
        dialog: false
      },
      mailRule: store.state.login.mailRule,
      usernameRule: store.state.login.usernameRule,
      passwordRule: store.state.login.passwordRule,
      agbRule: store.state.login.agbRule
    };
  },
  methods: {
    displayModal(title, content) {
      this.agb = false;
      this.modal.title = title;
      this.modal.content = content;
      this.modal.dialog = true;
    },
    submit() {
      var i = this.$refs.form.validate();
    }
  },
  components: {
    appModal
  }
};
</script>

<style>
.border-top-blue {
  border-top: 3px solid #0bafff !important;
}
</style>
