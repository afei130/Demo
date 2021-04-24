<template>
  <div>
    <HeadTabbar :title="$title" />
    <div>
      <div v-for="(item, index) in data" :key="index">
        <van-swipe-cell>
          <van-cell
            :title="item.Title"
            :value="$universal.DateFormat(item.CreateTime)"
            size="mini"
            :label="item.Content"
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
      user: {},
      show: true,
      data: [],
    };
  },
  created() {
    let _this = this;
    let user = JSON.parse(localStorage.getItem("user"));
    if (user != null) {
      _this.user = user;
      _this.GetData();
    }
  },
  methods: {
    GetData() {
      let _this = this;
      let user = _this.user;
      _this.$request.Post(
        "api/Article/MineList",
        {
          userid: user.UserId,
        },
        (res) => {
          _this.data = JSON.parse(res.data.Dic.data);
          if (_this.data.length > 0) {
            _this.show = false;
          }
        }
      );
    },
    Del(index) {
      let _this = this;
      let user = _this.user;
      let aid = _this.data[index].Id;
      _this.$request.Post(
        "api/Article/Del",
        {
          userid: user.UserId,
          aid: aid,
        },
        (res) => {
          _this.data.splice(index, 1);
          _this.$toast.success({
            message: res.data.Msg,
            duration: 2000,
          });
        }
      );
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
