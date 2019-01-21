<template>
  <div id="app" class="bg-secondary text-dark" style="font-family: 'Oregano', cursive;">
    <router-view />
  </div>
</template>

<script>
  export default {
    mounted() {
      //checks for valid session
      this.$store.dispatch("authenticate");
    },
  }
</script>
<style>
  #app {
    background-image: url('./assets/baalhead.jpg');
  }
</style>