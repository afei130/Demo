<template>
  <van-empty
    class="no-data"
    :image="image[type]"
    v-show="show"
    description="暂无数据"
  />
</template>

<script>
export default {
  props: {
    show: {
      type: Boolean,
      default: false,
    },
    type: {
      type: Number,
      default: 0,
    },
  },
  data() {
    return {
      image: ["default", "error", "network", "search"],
    };
  },
};
</script>

<style scoped>
.no-data {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
/deep/ .van-empty__description {
  padding: 0;
}
</style>
