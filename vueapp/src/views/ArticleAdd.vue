<template>
  <div>
    <HeadTabbar
      :title="$title"
      :right="{ title: '草稿箱', to: 'ArticleDrafts' }"
      :to="'Mine'"
    />
    <div>
      <van-form @submit="Add()">
        <van-field
          :label-width="labelwidth"
          v-model="article.title"
          label="标题"
          placeholder="建议30个字左右"
          :rules="[{ required: true, message: '请填写标题' }]"
          required
        />
        <van-field
          :label-width="labelwidth"
          v-model="article.content"
          :rows="rows"
          autosize
          label="正文"
          type="textarea"
          placeholder="请输入正文"
          :maxlength="maxlength"
          show-word-limit
        />
        <van-field label="分类" :label-width="labelwidth">
          <template #input>
            <van-checkbox-group
              v-model="article.classify_show"
              direction="horizontal"
            >
              <van-checkbox
                v-for="(item, index) in arr"
                :key="index"
                :name="item.name"
                shape="square"
                >{{ item.value }}</van-checkbox
              >
            </van-checkbox-group>
          </template>
        </van-field>
        <div style="margin: 16px;">
          <van-button round block type="info" native-type="submit"
            >发布</van-button
          >
        </div>
      </van-form>
      <div style="margin: 16px;">
        <van-button round block type="info" @click="SaveDraft()"
          >存为草稿</van-button
        >
      </div>
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
      labelwidth: "50px",
      rows: 10,
      maxlength: 10000,
      article: {
        title: "",
        content: "",
        classify: "",
        classify_show: [],
        datetime: "",
      },
      arr: [
        {
          name: 1,
          value: "搞笑",
        },
        {
          name: 2,
          value: "生活",
        },
        {
          name: 3,
          value: "游戏",
        },
        {
          name: 4,
          value: "哲学",
        },
        {
          name: 5,
          value: "科学",
        },
        {
          name: 6,
          value: "美食",
        },
      ],
    };
  },
  created() {
    let _this = this;
    let articleList = JSON.parse(localStorage.getItem("articleList"));
    if (articleList != null) {
      if (articleList.length > 0) {
        _this.article = articleList[0];
      }
    }
  },
  methods: {
    Add() {
      let _this = this;
      let user = JSON.parse(localStorage.getItem("user"));
      if (user == null) {
        _this.$universal.ToView("Login");
        _this.$toast.fail({
          message: "没登录捏,登着先喂",
          duration: 2000,
        });
      } else {
        let article = _this.article;
        article.classify = ",";
        let arr = article.classify_show;
        arr.forEach((item) => {
          article.classify += item + ",";
        });
        _this.$request.Post(
          "api/Article/Add",
          {
            userid: user.UserId,
            article: JSON.stringify(article),
          },
          (res) => {
            _this.$universal.ToView(res.data.ToUrl);
            _this.$toast.success({
              message: res.data.Msg,
              duration: 2000,
            });
          }
        );
      }
    },
    SaveDraft() {
      let _this = this;
      let article = _this.article; //编辑的文章
      if (article.title.length > 0) {
        article.datetime = _this.$universal.DateFormat(new Date());
        let saveName = "articleList"; //保存对象名称
        let articleList = JSON.parse(localStorage.getItem(saveName));
        if (articleList != null) {
          articleList.push(article);
          localStorage.setItem(saveName, JSON.stringify(articleList));
          _this.$toast.success({
            message: "已保存草稿",
            duration: 2000,
          });
        } else {
          articleList = [];
          articleList.push(article);
          localStorage.setItem(saveName, JSON.stringify(articleList));
          _this.$toast.success({
            message: "已保存草稿",
            duration: 2000,
          });
        }
      } else {
        _this.$toast.fail({
          message: "请填写标题",
          duration: 2000,
        });
      }
    },
  },
};
</script>

<style scoped>
.van-checkbox {
  margin-bottom: 5px;
}
</style>
