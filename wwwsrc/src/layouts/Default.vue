<template>
  <q-layout view="lHh Lpr lFf" class="text-tertiary">
    <q-layout-header>

      <q-toolbar color="primary" :inverted="$q.theme === 'ios'">
        <div class="text-center text-light absolute-middle">Baa'l's Mystery Emporium</div>
        <!-- <q-btn flat dense round @click="leftDrawerOpen = !leftDrawerOpen" aria-label="Menu" icon="menu" /> -->

        <q-toolbar-title class=" row justify-center absolute-center">
          <h4 class="col-12 text-light text-center">BAA'LMY</h4>

        </q-toolbar-title>
        <router-link v-if="user.id" :to="{name: 'home'}">
          <q-btn flat class="absolute-right text-light" label="Logout" style="color:white" @click="logout" />
        </router-link>
        <q-btn v-else flat label="Login" style="color:white" class="absolute-right" @click="opened=true" />
      </q-toolbar>
    </q-layout-header>

    <!-- <q-layout-drawer v-model="leftDrawerOpen" :content-class="$q.theme === 'mat' ? 'bg-grey-2' : null">
      <q-list no-border link inset-delimiter>
        <q-list no-border link inset-delimiter>
          <q-list-header>Navigation</q-list-header>
          <q-item to="/" exact>
            <q-item-side icon="home" />
            <q-item-main label="Home" />
          </q-item>
          <q-item to="/about">
            <q-item-side icon="info_outline" />
            <q-item-main label="About" />
          </q-item>
          <q-item-separator />
          <q-list-header>Essential Links</q-list-header>
          <q-item @click.native="openURL('http://quasar-framework.org')">
            <q-item-side icon="school" />
            <q-item-main label="Docs" sublabel="quasar-framework.org"></q-item-main>
          </q-item>
          <q-item @click.native="openURL('https://discord.gg/5TDhbDg')">
            <q-item-side icon="chat" />
            <q-item-main label="Discord Chat Channel" sublabel="https://discord.gg/5TDhbDg"></q-item-main>
          </q-item>
          <q-item @click.native="openURL('http://forum.quasar-framework.org')">
            <q-item-side icon="forum" />
            <q-item-main label="Forum" sublabel="forum.quasar-framework.org"></q-item-main>
          </q-item>
          <q-item @click.native="openURL('https://twitter.com/quasarframework')">
            <q-item-side icon="rss feed" />
            <q-item-main label="Twitter" sublabel="@quasarframework"></q-item-main>
          </q-item>
        </q-list>
      </q-list>
    </q-layout-drawer> -->

    <q-page-container>
      <q-modal v-model="opened" :content-css="{minWidth: '80vw', minHeight: '80vh'}" class="row vertical-middle d-flex justify-center">
        <q-modal-layout class="col vertical-middle d-flex justify-center absolute-center">
          <form class="row d-flex justify-center" v-if=" loginForm">
            <q-toolbar slot="header">
              <q-toolbar-title>
                LOGIN
              </q-toolbar-title>
            </q-toolbar>
            <q-input class="col-12 q-my-md" float-label="Email" v-model="creds.email" />
            <q-input class="col-12 q-my-md" float-label="Password" type="password" v-model="creds.password" />
            <q-btn class="col-12 q-my-xl" @click.prevent="loginUser" label="Login" />
          </form>
          <form class="row d-flex justify-center" v-else>
            <q-toolbar slot="header">
              <q-toolbar-title>
                REGISTER
              </q-toolbar-title>
            </q-toolbar>
            <q-input class="col-12 q-my-md" float-label="Username" type="text" v-model="newUser.username" />
            <q-input class="col-12 q-my-md" float-label="Email" type="email" v-model="newUser.email" />
            <q-input class="col-12 q-my-md" float-label="Password" type="password" v-model="newUser.password" />
            <q-btn class="col-12 q-my-xl" @click.prevent="register" label="Create Account" />
          </form>
          <div class="row fixed-bottom q-pt-lg d-flex justify-center"" @click=" loginForm=!loginForm">
            <q-btn v-if="loginForm" label="Create an account?" />
            <q-btn v-else label="Already have an account?" />
          </div>
          </div>
        </q-modal-layout>
      </q-modal>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
  import { openURL } from 'quasar'

  export default {
    name: 'LayoutDefault',
    data() {
      return {
        leftDrawerOpen: false,
        opened: false,
        loginForm: true,
        creds: {
          email: "",
          password: ""
        },
        newUser: {
          email: "",
          password: "",
          username: ""
        },
      }
    },
    computed: {
      user() {
        return this.$store.state.user
      }
    },
    methods: {
      openURL,
      register() {
        this.$store.dispatch("register", this.newUser);
        this.opened = false
      },
      loginUser() {
        this.$store.dispatch("login", this.creds);
        this.opened = false
      },
      logout() {
        let user = {}
        this.$store.dispatch('logout', user)
      }
    },
    components: {
    }
  }
</script>

<style>
</style>