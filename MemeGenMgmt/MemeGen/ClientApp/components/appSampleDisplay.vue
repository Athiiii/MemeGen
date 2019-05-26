<template>
    <v-parallax dark :src="'dist/901c8cbe68192f10ffa56c9257b53db5.jpg'" height="700">
      <v-layout align-center justify-center row fill-height wrap class="mb-5">
        <v-flex xs12 sm6 md4 lg3>
          <v-text-field
            label="Search for a Meme"
            append-icon="search"
            background-color="white"
            box light
          ></v-text-field>
        </v-flex>
      </v-layout>
    </v-parallax>
</template>

<script>
export default {
  data() {
    return {};
  },
  methods: {}
};
</script>
