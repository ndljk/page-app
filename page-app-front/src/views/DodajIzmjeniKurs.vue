<template>
  <div class="container">
    <form @submit.prevent="onSubmit">
      <label>
        Naziv kursa
        <small class="obavezno-polje">* </small>
        <small class="obavezno-polje" v-if="v$.naziv.$error">{{ v$.naziv.$errors[0].$message }}</small>
      </label>
      <input v-model="state.naziv" name="naziv" type="text" placeholder="Unesite naziv..">
      <label>Studenti pohađaju kurs</label>
      <select v-model="student" id="status" name="status">
        <option v-for="student in studenti" :value="student.id" :key="student.id">
          {{ student.ime }} {{ student.prezime }}
        </option>
      </select>
      <Button tip="submit" text="Sačuvaj kurs" />
    </form>
  </div>
</template>

<script>
import Button from '../components/Button.vue'
import useValidate from '@vuelidate/core'
import { required } from '@vuelidate/validators'
import { reactive, computed } from 'vue'
import axios from 'axios'

export default {
  name: 'DodajIzmjeniKurs',
  components: {
    Button
  },
  setup () {
    const state = reactive({
      naziv: ''
    })

    const rules = computed(() => {
      return {
        naziv: { required }
      }
    })

    const v$ = useValidate(rules, state)

    return {
      state,
      v$
    }
  },
  async created () {
    const response = await axios.get('Studenti/dohvati-studente')
    this.studenti = response.data
  },
  data () {
    return {
      studenti: []
    }
  },
  methods: {
    onSubmit () {
      this.v$.$validate()
      const data = {
        Naziv: this.state.naziv,
        StudentIds: this.studenti
      }

      console.log(data)
    }
  }
}
</script>

<style scoped>
.container {
  width: 100%;
  padding-right: 50px;
  padding-left: 50px;
  margin-top: 15px;
  margin-right: auto;
  margin-left: auto;
}

input[type=text], select {
  width: 100%;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
  margin-top: 6px;
  margin-bottom: 16px;
}

.inline-chkbox {
  display:inline-block;
  width:50%;
}

.checkbox-container {
  margin: auto;
  text-align: center;
  width: 75%;
  height: auto;
  max-height: 250px;
  padding: 12px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
  margin-top: 6px !important;
  margin-bottom: 16px;
  overflow-y: scroll;
}
.obavezno-polje {
  color: red;
}
</style>
