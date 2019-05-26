<template>
  <v-layout row justify-center>
    <v-flex xs12 sm8 md5 lg3>
      <v-dialog v-model="dialog" scrollable>
        <v-card>
          <v-card-title class="headline gray lighten-2">
            <h3>{{title}}</h3>
          </v-card-title>
          <v-card-text style="height: 300px;">
              <appTermsOfUse v-if="content == 'terms'"/>
              <appPrivacyPolicy v-else/>
          </v-card-text>
          <v-divider></v-divider>
          <v-card-actions>
            <v-btn color="blue darken-1" @click="dialog = false" flat>Ok</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-flex>
  </v-layout>
</template>

<script>
import appTermsOfUse from "./agb/appTermsOfUse"
import appPrivacyPolicy from "./agb/appPrivacyPolicy"

export default {
  props: ["title", "content", "dialog"],
  components: {
      appTermsOfUse, appPrivacyPolicy
  }
};
</script>
