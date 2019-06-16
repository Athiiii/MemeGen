<template>
  <v-card class="ma-4" elevation="16" raisedd>
    <v-card-title class="title font-weight-bold ml-1">Create your own Meme</v-card-title>
    <v-layout align-center justify-start wrap class="ma-2">
      <v-flex xs12 sm12 md5 lg3>
        <v-text-field label="Meme name (optional)" class="mt-2 ml-2"></v-text-field>
      </v-flex>
      <v-flex xs12 sm12 md12 lg12>
        <v-btn v-if="templateImg === null" @click="loadImage" color="info">
          <v-icon class="pr-2">add_photo_alternate</v-icon>Select Image
        </v-btn>
        <input type="file" ref="file" style="display:none" accept="image/*" @change="previewImage">
      </v-flex>
      <img :src="`${imageData}`">
      {{imageData}}
    </v-layout>
  </v-card>
</template>

<script>
import store from "../../store/index";

export default {
  data() {
    return {
      templateImg: store.state.meme.templateImg,
      imageData: ""
    };
  },
  methods: {
    loadImage() {
      var data = this.$refs.file.click();
    },
    previewImage: function(event) {
      console.log(this.imageData);
      var input = event.target;
      if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = e => {
          this.imageData = e.target.result;
          console.log(this.imageData);
        };
        reader.readAsDataURL(input.files[0]);
      }
    }
  }
};
</script>

