<template>
  <q-page padding>
    <Mystery v-for="mystery in mysteries" @click="selectMystery" />
  </q-page>
</template>

<script>
  import Mystery from './components/Mystery'
  export default {
    name: 'Profile',
    computed: {
      mysteries() {
        return this.$store.state.mysteries
      }
    },
    methods: {
    },
    components: {
      Mystery
    }
  }
</script>