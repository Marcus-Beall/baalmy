<template>
  <q-card @click="selectMystery">
    <q-card-title>
      {{mystery.Name}}
    </q-card-title>
    <q-card-separator />
    <q-card-main>
      {{mystery.Description}}
    </q-card-main>
  </q-card>
</template>

<script>
  export default {
    name: 'mystery',
    props: ['mystery'],
    computed: {
      user() {
        this.$store.state.user
      }
    },
    methods: {
      selectMystery() {
        this.$store.dispatch('selectMystery', this.mystery)
      }
    }
  }
</script>