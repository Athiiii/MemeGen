<template>
  <div ref="stageParent" class="jdalkdjlaskj">
    <v-stage ref="stage" :config="stageSize">
      <v-layer ref="layer">
        <v-image ref="image" :config="{
            image: configImage
          }" />
        <app-drag-able-text></app-drag-able-text>
      </v-layer>
    </v-stage>
  </div>
</template>

<script>
import appDragAbleText from "./appDragAbleText";
import { debuglog } from "util";

export default {
  props: ["image"],
  data() {
    return {
      stageSize: {
        width: 100,
        height: 100
      },
      configImage: null
    };
  },
  components: {
    appDragAbleText
  },
  methods: {
    createImage(data, height, width) {},
    prepeareCanvas() {
      const image = new window.Image();
      image.onload = () => {
        var container = this.$refs.stageParent;
        var imageRef = this.$refs.image;
        // now we need to fit stage into parent
        var containerWidth = container.offsetWidth;

        var stage = this.$refs.stage;
        stage.config.width = containerWidth;
        stage.config.height = containerWidth;
        this.stageSize.width = containerWidth;
        this.stageSize.height = containerWidth;

        image.height = this.stageSize.height;
        image.width = this.stageSize.width;
        this.configImage = image;
      };

      image.src = data;
    }
  },
  mounted() {
    this.prepeareCanvas();
    window.addEventListener("resize", () => {
      this.prepeareCanvas();
    });
  }
};
</script>