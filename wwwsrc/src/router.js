import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import DefaultLayout from './layouts/Default.vue'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import About from './views/About.vue'
// @ts-ignore
import Login from './views/Login.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: DefaultLayout,
      children: [
        {
          path: '',
          name: 'home',
          component: Home
        },
        {
          path: '/about',
          name: 'about',
          component: About
        },
        {
          path: '/login',
          name: 'login',
          component: Login
        }
      ]
    }
  ]
})
