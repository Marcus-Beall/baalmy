<template>
  <q-page class="flex flex-center">
    <img class="absolute-center" alt="Quasar logo" src="../assets/baalhead.jpg">
  </q-page>
</template>

<style>
</style>

<script>
  export default {
    name: 'PageHome',
    data() {
      return {
      }
    },
    mounted() {
    },
    computed: {
      user() {
        return this.store.$state.user
      }
    },
    methods: {
    },
  }
</script>