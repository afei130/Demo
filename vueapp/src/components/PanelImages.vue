<template>
  <div class="panel-images">
    <div class="item" v-for="(item, index) in 9" :key="index">
      <div
        class="image"
        :style="{
          'background-image':
            'url(https://picsum.photos/360/460?random=' + item + ')',
        }"
      />
    </div>
  </div>
</template>

<script>
export default {
  props: {
    dataItme: {
      type: Number,
      default: 0,
    },
  },
  data() {
    return {};
  },
  methods: {},
};
</script>

<style scoped>
/* 图片集合 */
.panel-images {
  display: flex;
  justify-content: flex-start;
  flex-wrap: wrap;
}

.item {
  width: 33%;
  height: 100px;
  margin-top: 1px;
}

.image {
  width: 100%;
  height: 100%;
  background-size: cover;
  background-position: center;
}

.item:not(:nth-child(3n)) {
  margin-right: 1px;
}

/* 只有一张图时 */
.item:nth-last-child(1):first-child {
  width: 200px;
  height: 200px;
}

.item:nth-last-child(4):first-child ~ .item:nth-child(2n) {
  margin-right: 33%;
}

.item:nth-last-child(4):first-child,
.item:nth-last-child(4):first-child ~ .item {
  margin-right: 1px;
}
</style>
