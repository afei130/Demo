<template>
  <van-nav-bar
    :title="title"
    :fixed="true"
    placeholder
    left-arrow
    left-text="返回"
    :right-text="right.title"
    @click-left="onClickLeft"
    @click-right="onClickRight"
  />
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      default: "",
    },
    to: {
      type: String,
      default: "",
    },
    right:{
      type:Object,
      default(){
        return{
          title:"",
          to:""
        }
      }
    }
  },
  methods: {
    onClickLeft() {
      let _this = this;
      if (_this.to.length > 0) {
          _this.$universal.ToView(_this.to);
      } else {
        _this.$router.go(-1); //返回上一层
      }
    },
    onClickRight() {
      let _this = this;
      if(_this.right.to.length > 0){
        _this.$universal.ToView(_this.right.to);
      }
    },
  },
};
</script>

<style scoped></style>
