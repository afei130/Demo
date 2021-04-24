<template>
  <div class="panel">
    <div class="card-head">
      <img class="users-photo" :src="require('@/assets/images/'+dataItme.UserAvatar)"/>
      <div class="users-name">{{dataItme.UserId}}</div>
    </div>
    <div class="card-body">
      <div class="card-body-title">
        {{dataItme.Title}}
      </div>
      <div class="card-body-content">
        {{dataItme.Content}}
      </div>
      <!-- <PanelImages :dataItme="dataItme.Id" /> -->
    </div>
    <div class="card-foot">
        <LikeCommentsForward />
    </div>
  </div>
</template>

<script>
// import PanelImages from "@/components/PanelImages";
import LikeCommentsForward from "@/components/LikeCommentsForward";
export default {
  props: {
    dataItme: {
      type: Object,
      default() {
        return {};
      },
    },
  },
  components: {
    // PanelImages,
    LikeCommentsForward
  }
};
</script>

<style scoped>
.panel {
  background:white;
  padding: 10px 15px;
}

.panel > div {
  margin-top: 5px;
}

.panel > div:first-child {
  margin-top: 0;
}

.card-head {
  display: flex;
  justify-content: flex-start;
  align-items: center;
}

.users-photo {
  width: 35px;
  height: 35px;
  border-radius: 50%;
}

.users-name {
  margin-left: 10px;
  font-weight: 700;
}

.users-name,
.card-body-content {
  font-size: 14px;
}

.card-body-title {
  font-size: 15px;
  padding-bottom: 5px;
}

.card-body-title,
.card-body-content {
  letter-spacing: 2px;
}
</style>
