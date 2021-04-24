import Vue from 'vue'
import VueRouter from 'vue-router'
Vue.use(VueRouter)
//解决编程式路由往同一地址跳转时会报错的情况
const originalPush = VueRouter.prototype.push
const originalReplace = VueRouter.prototype.replace
//push
VueRouter.prototype.push = function push(location, onResolve, onReject) {
  if (onResolve || onReject) return originalPush.call(this, location, onResolve, onReject)
  return originalPush.call(this, location).catch(err => err)
}
//replace
VueRouter.prototype.replace = function push(location, onResolve, onReject) {
  if (onResolve || onReject) return originalReplace.call(this, location, onResolve, onReject)
  return originalReplace.call(this, location).catch(err => err)
}

const router = new VueRouter({
  routes: [
    {
      path: '/',
      redirect: '/Home'
    },
    {
      path: '/Home',
      name: 'Home',
      meta: { title: "首页", keepAlive: true },
      component: resolve => require(['../views/Home'], resolve)
    },
    {
      path: '/Message',
      name: 'Message',
      meta: { title: "消息" },
      component: resolve => require(['../views/Message'], resolve)
    },
    {
      path: '/Mine',
      name: 'Mine',
      meta: { title: "我的", keepAlive: true },
      component: resolve => require(['../views/Mine'], resolve)
    },
    {
      path: '/ArticleAdd',
      name: 'ArticleAdd',
      meta: { title: "发布" },
      component: resolve => require(['../views/ArticleAdd'], resolve)
    },
    {
      path: '/ArticleDrafts',
      name: 'ArticleDrafts',
      meta: { title: "草稿箱" },
      component: resolve => require(['../views/ArticleDrafts'], resolve)
    },
    {
      path: '/Login',
      name: 'Login',
      meta: { title: "登录" },
      component: resolve => require(['../views/Login'], resolve)
    },
    {
      path: '/Register',
      name: 'Register',
      meta: { title: "注册" },
      component: resolve => require(['../views/Register'], resolve)
    },
    {
      path: '/TechnologyStack',
      name: 'TechnologyStack',
      meta: { title: "项目技术栈" },
      component: resolve => require(['../views/TechnologyStack'], resolve)
    },
    {
      path: '/Follow',
      name: 'Follow',
      meta: { title: "关注", keepAlive: true },
      component: resolve => require(['../views/Follow'], resolve)
    },
    {
      path: '/ArticleList',
      name: 'ArticleList',
      meta: { title: "文章" },
      component: resolve => require(['../views/ArticleList'], resolve)
    }
  ]
})

router.beforeEach((to, from, next) => {
  if (to.meta.title) {//如果设置标题，拦截后设置标题
    Vue.prototype.$title = to.meta.title;
  }
  next()
})

export default router
