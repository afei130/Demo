import Vue from 'vue'

import Vant from 'vant';
// import 'vant/lib/index.css';
import 'vant/lib/index.less';
Vue.use(Vant);

//事件返回提示消息
import { Toast } from 'vant';
Toast.setDefaultOptions({ forbidClick: true, });//加载时背景不能被点击
Toast.allowMultiple();//默认只有一个提示框,调用后允许出现多个窗口

//全局消息提示文字
Vue.prototype.$text = {
  loading: "加载中..."
};

Vue.config.productionTip = false;

//api请求
import request from './utils/request'
Vue.prototype.$request = request;

//配置信息
import config from './assets/config/index'

import axios from 'axios'
//拦截请求
axios.interceptors.request.use(request => {
  request.url = config.url + request.url;
  return request;
})
//拦截响应
// axios.interceptors.response.use(
//   response => {
//     if (response.status == 200) {
//       console.log(response)
//     }
//     return response;
//   },
//   error => {
//     return Promise.reject(error);
//   }
// );

//公共方法
import universal from './utils/universal'
Vue.prototype.$universal = universal;

//路由
import router from './router';

import App from './App.vue';

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
