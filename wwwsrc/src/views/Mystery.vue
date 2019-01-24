<template>
  <q-page :style-fn="myTweak">
    <q-card>
      <q-card-title>
      </q-card-title>
      <q-card-separator />
      <q-card-main>
      </q-card-main>
    </q-card>
  </q-page>
</template>

<script>
  export default {
    name: 'mysteryPage',
    computed: {
      mystery() {
        return this.$store.state.currentMystery
      }
    },
  }
</script>