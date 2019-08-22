<template>
  <v-card class="ma-4" elevation="16" raisedd>
    <v-card-title class="title font-weight-bold ml-1">Create your own Meme</v-card-title>
    <v-layout align-center justify-start wrap class="ma-2">
      <v-flex xs12 sm12 md5 lg3 ref="createMemeInput">
        <v-text-field label="Meme name (optional)" class="mt-2 ml-2" ref="createMemeInput"></v-text-field>
      </v-flex>
      <v-flex md7 lg9>
        <v-spacer></v-spacer>
      </v-flex>
      <v-flex xs12 sm6 md5 lg3>
        <v-btn v-if="templateImg === null" @click="loadImage" color="info">
          <v-icon class="pr-2">add_photo_alternate</v-icon>Select Image
        </v-btn>
        <app-meme-edit v-if="templateImg !== null" :image="image"></app-meme-edit>
        <input type="file" ref="file" style="display:none" accept="image/*" @change="previewImage" />
      </v-flex>
    </v-layout>
  </v-card>
</template>

<script>
import store from "../../store/index";
import appMemeEdit from "./appMemeEdit";

export default {
  data() {
    return {
      templateImg: store.state.meme.templateImg,
      image: null
    };
  },
  methods: {
    loadImage() {
      var data = this.$refs.file.click();
    },
    previewImage(event) {
      var input = event.target;
      if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = e => {
          this.templateImg = {
            imagePath: e.target.result
          };
          this.image = e.target.result;
        };
        reader.readAsDataURL(input.files[0]);
      }
    },
    createImage(data) {
      const image = new window.Image();
      image.src = data;
      image.onload = () => {
        this.image = image;
      };
    }
  },
  components: {
    appMemeEdit
  },
  created() {
    if (this.templateImg !== null) this.image = this.templateImg.imagePath;
  }
};
</script>

