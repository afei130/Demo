<template>
  <div class="message">
    <HeadTabbar :title="$title" />
    <div class="card" v-for="(item, index) in userData" :key="index">
      <img class="image" :src="require('@/assets/images/' + item.Tx)" />
      <div class="container">
        <div class="users-name all-nowrap">
          {{ item.Name }}
        </div>
        <div class="users-msg all-nowrap">
          内容描述
        </div>
      </div>
      <div class="date">
        01-08
      </div>
    </div>
  </div>
</template>

<script>
import datalist from "@/utils/data";
import HeadTabbar from "@/components/HeadTabbar";
export default {
  name: "Message",
  components: {
    HeadTabbar,
  },
  data() {
    return {
      userData: datalist.userData,
    };
  },
  created() {},
};
</script>
<style scoped>
.message {
  background: white;
}
.card {
  display: flex;
  justify-content: flex-start;
  align-items: center;
  border-bottom: solid 1px rgba(0, 0, 0, 0.1);
  padding: 10px;
}

.image {
  width: 50px;
  height: 50px;
  border-radius: 50%;
}

.container {
  flex: 1;
  margin-left: 10px;
}

.users-name {
  margin-bottom: 5px;
  font-size: 14px;
}

.date {
  margin-top: -25px;
}

.users-msg,
.date {
  font-size: 12px;
  color: #888;
}
</style>
