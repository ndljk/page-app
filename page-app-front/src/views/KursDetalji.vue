<template>
  <h1>{{data}}</h1>
</template>

<script>
import axios from 'axios'

export default {
  name: 'KursDetalji',
  async mounted () {
    this.id = this.$route.params.id
    const response = await axios.get(`Kursevi/dohvati-kurs/${this.$route.params.id}`)
    this.data = response.data
  },
  data () {
    return {
      id: null,
      data: []
    }
  }
}
</script>

<style scoped>

</style>
