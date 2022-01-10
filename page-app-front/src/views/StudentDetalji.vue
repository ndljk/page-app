<template>
<div>
<table class="center">
    <tr>
      <th>Broj indeksa</th>
      <th>Ime i prezime</th>
      <th>Godina studija</th>
      <th>Status studenta</th>
    </tr>
    <tr>
      <td>{{data.br_indeksa}}</td>
      <td>{{data.ime}} {{data.prezime}}</td>
      <td>{{data.godina}}</td>
      <td>{{data.statusStudenta}}</td>
    </tr>
  </table>
  <div class="warning">
    {{data.naziviKurseva}}
  </div>
  {{data}}
</div>

</template>

<script>
import axios from 'axios'

export default {
  name: 'StudentDetalji',
  async mounted () {
    this.id = this.$route.params.id
    const response = await axios.get(`Studenti/dohvati-studenta/${this.$route.params.id}`)
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
.center {
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  margin-left: auto;
  margin-right: auto;
  margin-top: 15%;
  width: 75%;
  text-align: center;
}
tr:nth-child(even) {
  background-color: #f2f2f2;
}
.warning {
  background-color: #ffffcc;
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  margin-left: auto;
  margin-right: auto;
  margin-top: 5px;
  width: 75%;
  text-align: center;
}
</style>
