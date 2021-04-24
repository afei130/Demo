<template>
  <div class="like-comments-forward">
    <div class="left">
      <div class="share">
        <van-icon name="share-o" />
        <div class="num">{{ obj.like }}</div>
      </div>
      <div class="comment">
        <van-icon name="comment-o" />
        <div class="num">{{ obj.comments }}</div>
      </div>
    </div>
    <div class="right">
      <div class="praise">
        <van-icon name="good-job-o" />
        <div class="num">{{ obj.forward }}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    obj: {
      type: Object,
      default() {
        return {
          like: "-",
          comments: "-",
          forward: "-",
        };
      },
    },
  },
};
</script>

<style scoped>
.like-comments-forward {
  justify-content: space-between;
  font-size: 14px;
  color: #888;
}

.left > div {
  margin-left: 10px;
}

.left > div:first-child {
  margin-left: 0;
}

.num {
  margin-left: 5px;
}

.like-comments-forward,
.left,
.right,
.share,
.comment,
.praise {
  display: flex;
}

.share,
.comment {
  justify-content: flex-start;
}

.like-comments-forward,
.left,
.right,
.share,
.comment {
  align-items: center;
}

.praise {
  justify-content: flex-end;
}
</style>
