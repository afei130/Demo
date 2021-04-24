<template>
  <div>
    <van-skeleton
      class="skeleton"
      title
      avatar
      :row="5"
      v-show="show"
      v-for="(item, index) in 5"
      :key="index"
    />
  </div>
</template>

<script>
export default {
  props: {
    show: {
      type: Boolean,
      default: false,
    },
  },
};
</script>

<style scoped>
.skeleton {
  padding: 10px;
}
</style>
