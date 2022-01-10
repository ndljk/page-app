<template>
  <div class="container">
    <form @submit.prevent="onSubmit">
      <label>Ime</label>
      <input v-model="ime" type="text" name="ime" placeholder="Unesite ime..">
      <label>Prezime</label>
      <input v-model="prezime" type="text" name="prezime" placeholder="Unesite prezime..">
      <label>Godina <small>(unijeti 5 ako je student apsolvent)</small></label>
      <input v-model="godina" type="number" name="godina" min="1" max="5">
      <label>
        Broj indexa
        <small class="obavezno-polje">* </small>
        <small class="obavezno-polje" v-if="v$.indeks.$error">{{ v$.indeks.$errors[0].$message }}</small>
      </label>
      <input v-model="state.indeks" type="text" name="indeks" placeholder="Unesite broj indeksa..">
      <label>Status studenta <small class="obavezno-polje">*</small></label>
      <select v-model="status" id="status" name="status">
        <option value="1">redovan</option>
        <option value="2">vanredan</option>
      </select>
      <label>Kursevi koje pohađa</label>
      <VueMultiselect
        :options="kursevi"
        :multiple="true"
        :label="kursevi">
      </VueMultiselect>
      <Button tip="submit" text="Sačuvaj studenta" />
    </form>
  </div>
</template>

<script>
import Button from '../components/Button.vue'
import useValidate from '@vuelidate/core'
import { required } from '@vuelidate/validators'
import { reactive, computed } from 'vue'
import axios from 'axios'
import VueMultiselect from 'vue-multiselect'

export default {
  name: 'DodajIzmjeniStudent',
  components: {
    Button,
    VueMultiselect
  },
  setup () {
    const state = reactive({
      indeks: ''
    })

    const rules = computed(() => {
      return {
        indeks: { required }
      }
    })

    const v$ = useValidate(rules, state)

    return {
      state,
      v$
    }
  },
  async created () {
    const response = await axios.get('Kursevi/dohvati-kurseve')
    console.log(response.data)
    this.kursevi = response.data
  },
  data () {
    return {
      ime: '',
      prezime: '',
      godina: '',
      indeks: '',
      status: 1,
      kursevi: []
    }
  },
  methods: {
    onSubmit () {
      this.v$.$validate()
      const data = {
        Br_indeksa: this.state.indeks,
        Ime: this.ime,
        Prezime: this.prezime,
        Godina: this.godina,
        StatusId: this.status,
        KursIds: this.kursevi
      }

      console.log(data)
    }
  }
}
</script>

<style src="vue-multiselect/dist/vue-multiselect.css"></style>
<style scoped>
.container {
  width: 100%;
  padding-right: 50px;
  padding-left: 50px;
  margin-top: 15px;
  margin-right: auto;
  margin-left: auto;
}

input[type=text], input[type=number], select {
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
  width:33%;
}

.checkbox-container {
  margin: auto;
  text-align: center;
  width: 75%;
  height: 50%;
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
</style>
