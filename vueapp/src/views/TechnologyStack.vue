<template>
  <div>
    <HeadTabbar :title="$title" />
    <div v-for="(itme1, index1) in data" :key="index1">
      <van-cell :title="itme1.title" icon="orders-o" value="" size="cell_size" />
      <van-cell v-for="(itme2, index2) in itme1.value" :key="index2" :title="itme2.name">
        <template #right-icon>
          <van-icon :name="itme2.icon" class="icon" />
        </template>
      </van-cell>
      <div class="interval" />
    </div>
  </div>
</template>

<script>
  import HeadTabbar from "@/components/HeadTabbar";
  export default {
    components: {
      HeadTabbar,
    },
    data() {
      return {
        cell_size: "mini",
        data: [
          {
            title: "前端",
            value: [
              {
                name: "HTML",
                icon: "passed",
              },
              {
                name: "CSS",
                icon: "passed",
              },
              {
                name: "JavaScript",
                icon: "passed",
              },
              {
                name: "Vue",
                icon: "passed",
              },
              {
                name: "Vant",
                icon: "passed",
              }
            ],
          },
          {
            title: "后端",
            value: [
              {
                name: "C#",
                icon: "passed",
              },
              {
                name: ".Net Core",
                icon: "passed",
              }, {
                name: "EntityFrameworkCore",
                icon: "passed",
              }
            ],
          },
          {
            title: "服务器",
            value: [
              {
                name: "Linux",
                icon: "passed",
              },
            ],
          },
          {
            title: "数据库",
            value: [
              {
                name: "MySql",
                icon: "passed",
              },
            ],
          }
        ],
      };
    },
  };
</script>

<style>
  .icon {
    font-size: 24px;
    color: #40eb68;
  }
</style>