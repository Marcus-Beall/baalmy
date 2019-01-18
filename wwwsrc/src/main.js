// @ts-ignore
import Vue from 'vue'
// @ts-ignore
import App from './App.vue'
import router from './router'
import store from './store'

import './styles/quasar.styl'
import 'quasar-extras/animate'
import 'quasar-extras/material-icons'
import 'quasar-extras/fontawesome'
// @ts-ignore
import Quasar from 'quasar'

// @ts-ignore
Vue.use(Quasar, {
  config: {}
})

Vue.config.productionTip = false

// @ts-ignore
new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
