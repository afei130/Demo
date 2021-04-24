<template>
  <div class="home">
    <div v-if="show.content">
      <van-search v-model="value" placeholder="请输入搜索关键词" />
      <van-pull-refresh v-model="refresh.isLoading" :success-text="refresh.text" @refresh="Refresh">
        <van-tabs v-model="active" color="#1989fa" line-height="2px" animated lazy-render>
          <van-tab :title="item.name" v-for="(item, index) in typeList" :key="index">
            <div v-for="(item2, index2) in data" :key="index2">
              <Panel :dataItme="item2" />
              <div class="interval" />
            </div>
          </van-tab>
        </van-tabs>
      </van-pull-refresh>
    </div>
    <Skeleton :show="show.skeleton" />
    <NoData :show="show.nodata" :type="3" />
  </div>
</template>

<script>
  import datalist from "@/utils/data";
  import Panel from "@/components/Panel";
  import NoData from "@/components/NoData";
  import Skeleton from "@/components/Skeleton";
  export default {
    name: "Home",
    components: {
      Panel,
      NoData,
      Skeleton,
    },
    data() {
      return {
        show: {
          skeleton: true, //骨架
          nodata: false, //无数据
          content: false, //正文
        },
        value: "",
        active: 0,
        typeList: datalist.typeList,
        userData: datalist.userData,
        data: [],
        refresh:{
          text:"刷新成功",
          isLoading:false
        }
      };
    },
    created() {
      let _this = this;
      _this.GetData();
    },
    methods: {
      GetData() {
        let _this = this;
        _this.$request.Post("api/Article/List", {}, (res) => {
          console.log(res)
          if (res.data.Code == 100) {
            _this.data = JSON.parse(res.data.Dic.data);
          } else {
            _this.$universal.LoadingTips(res.data.Msg, res.data.Code);
          }
          if (_this.data.length > 0) {
            _this.show.content = true;
          } else {
            _this.show.nodata = true;
          }
          _this.show.skeleton = false;
        });
      },
      Refresh(){
        let _this = this;
        _this.$request.Post("api/Article/List", {}, (res) => {
          if (res.data.Code == 100) {
            _this.data = JSON.parse(res.data.Dic.data);
          } else {
            _this.refresh.text = "刷新失败";
            _this.$universal.LoadingTips(res.data.Msg, res.data.Code);
          }
          _this.refresh.isLoading = false;
        },false);
      }
    },
  };
</script>