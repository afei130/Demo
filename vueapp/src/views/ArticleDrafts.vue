<template>
  <div>
    <HeadTabbar :title="$title" />
    <div>
      <div v-for="(item, index) in data" :key="index">
        <van-swipe-cell>
          <van-cell
            :title="item.title"
            :value="item.datetime"
            size="mini"
            :label="item.content"
            @click="Select(index)"
          />
          <template #right>
            <van-button type="danger" text="删除" @click="Del(index)" />
          </template>
        </van-swipe-cell>
        <div class="interval" />
      </div>
    </div>
    <NoData :show="show" :type="3" />
  </div>
</template>

<script>
import HeadTabbar from "@/components/HeadTabbar";
import NoData from "@/components/NoData";
export default {
  components: {
    HeadTabbar,
    NoData,
  },
  data() {
    return {
      show: true,
      data: [],
    };
  },
  created() {
    let _this = this;
    let articleList = JSON.parse(localStorage.getItem("articleList"));
    if (articleList != null) {
      if (articleList.length > 0) {
        _this.show = false;
        articleList = articleList.sort((a, b) =>
          a.datetime < b.datetime ? 1 : -1
        );
      }
      _this.data = articleList;
    }
  },
  methods: {
    Select(index) {
      let _this = this;
      let article = {};
      let articleList = _this.data;
      for (let i = 0; i < articleList.length; i++) {
        if (i === index) {
          article = articleList[i];
          articleList.splice(i, 1);
          break;
        }
      }
      articleList.unshift(article);
      localStorage.setItem("articleList", JSON.stringify(articleList));
      _this.$universal.ToView("ArticleAdd");
    },
    Del(index) {
      let _this = this;
      let articleList = _this.data;
      articleList.splice(index, 1);
      localStorage.setItem("articleList", JSON.stringify(articleList));
      if (articleList.length == 0) {
        _this.show = true;
      }
      _this.$toast.success({
        message: "删除成功",
        duration: 2000,
      });
    },
  },
};
</script>

<style scoped>
.van-button {
  height: 100%;
}
.van-cell__label {
  overflow: hidden;
  text-overflow: ellipsis;
  display: -webkit-box;
  -webkit-box-orient: vertical;
  -webkit-line-clamp: 2;
}
</style>
