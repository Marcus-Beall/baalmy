import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import DefaultLayout from './layouts/Default.vue'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Profile from './views/Profile.vue'

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
          path: '/profile',
          name: 'profile',
          component: Profile
        }
      ]
    }
  ]
})
