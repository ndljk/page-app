<template>
  <div>
    <Alert v-if="prikaziAlert" :alertText="alertText" :boja="bojaAlerta" />
    <Button text="Dodaj studenta"/>
    <div :key="student.id" v-for="student in studenti">
      <InfoTab
      @delete-emit="deleteTab"
      @info-emit="infoTab"
      :infotab="student"/>
    </div>
  </div>

</template>

<script>
import Button from '../components/Button.vue'
import InfoTab from '../components/InfoTab.vue'
import Alert from '../components/Alert.vue'
import axios from 'axios'

export default {
  name: 'Studenti',
  components: {
    Button,
    InfoTab,
    Alert
  },
  async created () {
    const response = await axios.get('Studenti/dohvati-studente')
    this.studenti = response.data
  },
  data () {
    return {
      prikaziAlert: false,
      alertText: 'Uspješno obrisano',
      bojaAlerta: 'success',
      logged: localStorage.getItem('token'),
      studenti: []
    }
  },
  methods: {
    async deleteTab (id) {
      // console.log('Student:', id)
      if (confirm('Da li ste sigurni?')) {
        const res = await axios.delete(`Studenti/obrisi-studenta/${id}`)
          .catch(() => {
            this.alertText = 'Dogodila se greška prilikom brisanja'
            this.bojaAlerta = 'alert'
            this.prikaziAlert = true
          })

        this.prikaziAlert = true
        if (res.status === 200) {
          this.studenti = (this.studenti.filter((student) => student.id !== id))
        }
      }
    }
  }
}
</script>
