<template>
  <div>
    <van-index-bar>
      <div v-for="(item1, index1) in data" :key="index1">
        <van-index-anchor :index="item1.index" />
        <van-cell
          v-for="(item2, index2) in item1.user"
          :key="index2"
          :title="item2.Name"
        />
      </div>
    </van-index-bar>
  </div>
</template>

<script>
import datalist from "@/utils/data";
export default {
  components: {
  },
  data() {
    return {
      data: [
        {
          index: "A",
          user: datalist.userData,
        },
        {
          index: "B",
          user: datalist.userData,
        },
        {
          index: "C",
          user: datalist.userData,
        },
        {
          index: "D",
          user: datalist.userData,
        },
        {
          index: "E",
          user: datalist.userData,
        },
        {
          index: "F",
          user: datalist.userData,
        },
        {
          index: "G",
          user: datalist.userData,
        },
      ],
    };
  },
  created() {},
};
</script>

<style></style>
