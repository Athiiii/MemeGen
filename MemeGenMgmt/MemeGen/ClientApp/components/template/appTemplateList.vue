<template>
  <div>
    <v-layout row wrap justify-center v-scroll="onScroll">
      <v-flex xs6 sm4 md4 lg2 v-for="img in displayData" :key="img.id" class="ma-3">
        <v-card v-ripple flat hover raised @click="createMeme(img)">
          <v-img :src="img.imagePath" :lazy-src="img.lazy" aspect-ratio="1" class="grey lighten-2">
            <template v-slot:placeholder>
              <v-layout fill-height align-center justify-center ma-0>
                <v-progress-circular indeterminate color="secondary" :size="60" width="6"></v-progress-circular>
              </v-layout>
            </template>
          </v-img>
          <v-card-title primary-title>
            <h3 class="headline mb-0">{{ img.name }}</h3>
          </v-card-title>
        </v-card>
      </v-flex>
      <v-flex justify-center xs12 sm12 md12 lg12 class="text-xs-center my-2" v-show="loading">
        <v-progress-circular :size="70" color="primary" indeterminate :width="6"></v-progress-circular>
        <br>
        <v-btn @click="loadMoreImg(10)" flat outline class="mt-2">Load more</v-btn>
      </v-flex>
    </v-layout>
  </div>
</template>

<script>
import axios from "axios";
import store from "../../store";

export default {
  data() {
    return {
      data: [],
      displayData: [],
      loadHeight: 0,
      loading: false
    };
  },
  methods: {
    onScroll(e) {
      var scroll = e.target.scrollingElement;

      if (
        scroll.offsetHeight - 50 <=
        scroll.scrollTop + e.path[1].innerHeight
      ) {
        this.loadMoreImg(10);
      }
    },
    loadMoreImg(count) {
      if (this.data !== null && this.data.length > count) {
        this.loading = true;
        this.data.slice(0, count).forEach(element => {
          this.displayData.push(element);
        });
        this.data.splice(0, count);
        var i = this.displayData;
      } else if (this.data !== null && this.data.length > 0) {
        console.log("end");
        this.data.forEach(element => {
          this.displayData.push(element);
        });
        this.data = null;
        this.loading = false;
      }
    },
    createMeme(img) {
      store.commit("setTemplate", img);
      this.$router.push("memeCreate");
    }
  },
  mounted() {
    this.loading = true;
    axios.get("/api/template").then(response => {
      axios.get("lazyLoad.json").then(lazyData => {
        response.data.forEach(element => {
          var data = lazyData.data.find(pair => {
            return pair.Name === `${element.name}.jpg`;
          });
          element["lazy"] = data.Data;
        });
        this.data = response.data;
        this.loadMoreImg(20);
      });
    });
  }
};
</script>

