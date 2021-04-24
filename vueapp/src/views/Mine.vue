<template>
  <div class="mine">
    <BigCell :user="userData" />
    <div class="interval" />
    <van-cell
      title="发布"
      icon="edit"
      value=""
      size="cell_size"
      is-link
      to="/ArticleAdd"
    />
    <van-cell title="文章" icon="orders-o" value="" size="cell_size" is-link to="/ArticleList" />
    <van-cell title="收藏" icon="star-o" value="" size="cell_size" is-link />
    <van-cell
      title="消息"
      icon="chat-o"
      value=""
      size="cell_size"
      is-link
      to="/Message"
    />
    <van-cell title="设置" icon="setting-o" value="" size="cell_size" is-link />
    <div class="interval" />
    <van-cell title="GitHub" value="" size="cell_size" is-link />
    <van-cell
      title="项目技术栈"
      value=""
      size="cell_size"
      is-link
      to="/TechnologyStack"
    />
    <div class="interval" />
    <van-button @click="OutLogin()" type="default" hairline block
      >退出</van-button
    >
  </div>
</template>

<script>
import BigCell from "@/components/BigCell";
export default {
  name: "Mine",
  components: {
    BigCell,
  },
  data() {
    return {
      cell_size: "mini",
      userData: {
        Id:"-",
        UserId: "尚未登录",
        UserAvatar: "tx1.jpg",
      },
    };
  },
  created() {
    let user = JSON.parse(localStorage.getItem("user"));
    if (user) {
      this.userData = user;
    }
  },
  methods: {
    OutLogin() {
      let _this = this;
      _this.$universal.LoadingTips(_this.$text.loading);
      if (localStorage.getItem("user") != null) {
        localStorage.removeItem("user");
      }
      setTimeout(() => {
        _this.$universal.ToView("Login");
      }, 1000);
    },
  },
};
</script>
<style scoped></style>
