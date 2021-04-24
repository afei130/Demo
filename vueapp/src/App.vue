<template>
  <div id="app">
    <keep-alive>
      <router-view v-if="$route.meta.keepAlive" />
    </keep-alive>
    <router-view v-if="!$route.meta.keepAlive" />
    <BottomTabbar />
  </div>
</template>
<script>
  import BottomTabbar from "@/components/BottomTabbar";
  export default {
    components: {
      BottomTabbar
    },
  };
</script>
<style>
  html {
    height: 100%;
    background: #f7f8fa;
  }

  .interval {
    width: 100%;
    height: 10px;
  }
</style>