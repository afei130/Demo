<template>
  <div class="big-cell">
    <van-popover
      v-model="showPopover"
      placement="right-start"
      :overlay="true"
      trigger="click"
    >
      <van-grid
        square
        clickable
        :border="false"
        column-num="3"
        style="width: 240px;"
      >
        <van-grid-item
          v-for="(item, index) in txList"
          :key="index"
          :text="'头像' + (index + 1)"
          :icon="require('@/assets/images/' + item.Tx)"
          @click="UpdateUserAvatar(index)"
        />
      </van-grid>
      <template #reference>
        <img class="tx" :src="require('@/assets/images/' + user.UserAvatar)" />
      </template>
    </van-popover>
    <div class="info">
      <div class="name">{{ user.UserId }}</div>
      <div class="id">ID：{{ user.Id }}</div>
    </div>
    <div></div>
  </div>
</template>

<script>
import datalist from "@/utils/data";
export default {
  props: {
    user: {
      type: Object,
      default() {
        return {};
      },
    },
  },
  data() {
    return {
      txList: datalist.userData,
      showPopover: false,
    };
  },
  methods: {
    UpdateUserAvatar(index) {
      let _this = this;
      _this.showPopover = false;
      let UserAvatar = _this.txList[index].Tx;
      let user = JSON.parse(JSON.stringify(_this.user)); //使用json实现深度拷贝
      user.UserAvatar = UserAvatar;
      _this.$request.Post(
        "api/User/UpdateUserAvatar",
        {
          user: JSON.stringify(user),
        },
        (res) => {
          let data = JSON.parse(localStorage.getItem("user"));
          if (data != null) {
            //更新到浏览器缓存
            data.UserAvatar = UserAvatar;
            localStorage.setItem("user", JSON.stringify(data));
            _this.user.UserAvatar = UserAvatar;
          }
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

<style>
.big-cell {
  display: flex;
  justify-content: flex-start;
  background: white;
  padding: 30px 20px;
}
.tx {
  border-radius: 10px;
  width: 70px;
  height: 70px;
  margin-right: 10px;
}
.info {
  display: flex;
  flex-direction: column;
}
.name {
  font-size: 18px;
}
.id {
  font-size: 14px;
  color: #888;
}
</style>
