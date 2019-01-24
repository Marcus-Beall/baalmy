import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    mysteries: [],
    secrets: [],
    currentMystery: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
      console.log(user)
    },
    setMysteries(state, mysteries) {
      state.mysteries = mysteries
      console.log(mysteries)
    },
    setSecrets(state, secrets) {
      state.secrets = secrets
    },
    setMystery(state, mystery) {
      state.currentMystery = mystery
    }
  },
  actions: {
    //AUTH
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          console.log(res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }, user) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', user),
            router.push({ name: 'home' })
        }
        )
    },

    //MYSTERIOUS STUFF
    getMysteries({ commit, dispatch }, userId) {
      api.get('mysteries/' + userId)
        .then(res => {
          commit('setMysteries', res.data)
          router.push({ name: 'home' })
        })
    },
    makeMystery({ commit, dispatch }, mystery) {
      console.log(mystery)
      api.post('mysteries', mystery)
        .then(res => {
          console.log(res.data)
          commit('setMysteries', res.data)
        })
    },
    selectMystery({ commit, dispatch }, mystery) {
      commit('setMystery', mystery)
      router.push({ name: 'mystery' })
    },

    //SECRET STUFF
    makeSecret({ commit, dispatch }, secret) {
      console.log(secret)
      api.post('secrets', secret)
        .then(res => {
          commit('setSecrets', res.data)
        })
    },
    getSecrets({ commit, dispatch }, user) {
      api.get('secrets', user.id)
        .then(res => {
          commit('setSecrets', res.data)
        })
    }
  }
})