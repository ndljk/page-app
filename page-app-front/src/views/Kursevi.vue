<template>
  <div>
    <Alert v-if="prikaziAlert" :alertText="alertText" :boja="bojaAlerta" />
    <Button text="Dodaj kurs"/>
    <div :key="kurs.id" v-for="kurs in kursevi">
      <InfoTabKurs
      @delete-emit="deleteTab"
      @info-emit="infoTab"
      :infotab="kurs"/>
    </div>
  </div>
</template>

<script>
import Button from '../components/Button.vue'
import InfoTabKurs from '../components/InfoTabKurs.vue'
import Alert from '../components/Alert.vue'
import axios from 'axios'

export default {
  name: 'Kursevi',
  components: {
    Button,
    InfoTabKurs,
    Alert
  },
  async created () {
    const response = await axios.get('Kursevi/dohvati-kurseve')
    this.kursevi = response.data
  },
  data () {
    return {
      prikaziAlert: false,
      alertText: 'Uspješno obrisano',
      bojaAlerta: 'success',
      logged: localStorage.getItem('token'),
      kursevi: []
    }
  },
  methods: {
    async deleteTab (id) {
      if (confirm('Da li ste sigurni?')) {
        const res = await axios.delete(`Kursevi/obrisi-kurs/${id}`)
          .catch(() => {
            this.alertText = 'Dogodila se greška prilikom brisanja'
            this.bojaAlerta = 'alert'
            this.prikaziAlert = true
          })

        this.prikaziAlert = true
        if (res.status === 200) {
          this.kursevi = this.kursevi.filter((kurs) => kurs.id !== id)
        }
      }
    }
  }
}
</script>
