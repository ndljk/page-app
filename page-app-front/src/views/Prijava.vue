<template>
  <div class="main">
    <div class="img-container">
      <img :src="image" alt="Page slika">
    </div>
    <Alert v-if="alertInfo" alertText="Pogrešni kredencijali!" boja="alert" />
    <form @submit.prevent="submitForm">
      <div class="validation-info" v-if="v$.korisnicko.$error">{{ v$.korisnicko.$errors[0].$message }}</div>
      <input
        class="korisnicko"
        type="text" align="center"
        placeholder="Korisničko ime"
        v-model="state.korisnicko">
      <div class="validation-info" v-if="v$.pass.$error">{{ v$.pass.$errors[0].$message }}</div>
      <input
        class="pass"
        :type="passVisible ? 'text' : 'password'"
        align="center" placeholder="Lozinka"
        v-model="state.pass">
      <button @click="prikaziLozinku" class="prikazi" type="button">
        <i :class="passVisible ? 'fa fa-eye-slash' : 'fa fa-eye'"></i></button>
      <button class="submit" align="center" >Prijavi se</button>
    </form>
  </div>
</template>

<script>
import image from '../assets/page_icon-removebg-preview.png'
import useValidate from '@vuelidate/core'
import { required, minLength } from '@vuelidate/validators'
import { reactive, computed } from 'vue'
import Alert from '../components/Alert.vue'
import axios from 'axios'

export default {
  name: 'Prijava',
  setup () {
    const state = reactive({
      korisnicko: '',
      pass: ''
    })

    const rules = computed(() => {
      return {
        korisnicko: { required },
        pass: { required, minLength: minLength(6) }
      }
    })

    const v$ = useValidate(rules, state)

    return {
      state,
      v$
    }
  },
  data () {
    return {
      image: image,
      passVisible: false,
      alertInfo: false
    }
  },
  methods: {
    prikaziLozinku () {
      this.passVisible = !this.passVisible
    },
    async submitForm (e) {
      this.v$.$validate()

      if (!this.v$.$error) {
        const response = await axios.post('Korisnici/login', {
          Korisnicko_ime: this.state.korisnicko,
          Lozinka: this.state.pass
        }).catch(this.alertInfo = true)

        localStorage.setItem('token', response.data.token)

        this.$router.push('/studenti')
      }
    }
  },
  components: {
    Alert
  }
}
</script>

<style scoped>
.img-container {
  text-align: center;
}
.prikazi{
  margin-left: -30px;
  height: 25px;
  width: 25px;
  background: grey;
  color: white;
  border: 0;
  -webkit-appearance: none;
  border: none;
  border-radius: 50%;
  font-weight: 700;
  font-size: 14px;
}
.prikazi:hover{
  cursor: pointer;
}
.main {
  width: 400px;
  height: 460px;
  margin: 70px auto;
  border-radius: 1.5em;
  box-shadow: 0px 11px 35px 2px rgba(0, 0, 0, 0.14);
}
.korisnicko {
  width: 76%;
  color: rgb(38, 50, 56);
  font-weight: 700;
  font-size: 14px;
  letter-spacing: 1px;
  background: rgba(136, 126, 126, 0.04);
  padding: 10px 20px;
  border-radius: 20px;
  outline: none;
  box-sizing: border-box;
  border: 2px solid rgba(0, 0, 0, 0.18);
  margin-left: 46px;
  text-align: center;
  margin-bottom: 27px;
  font-family: 'Ubuntu', sans-serif;
}
.pass {
  width: 76%;
  color: rgb(38, 50, 56);
  font-weight: 700;
  font-size: 14px;
  letter-spacing: 1px;
  background: rgba(136, 126, 126, 0.04);
  padding: 10px 20px;
  border-radius: 20px;
  outline: none;
  box-sizing: border-box;
  border: 2px solid rgba(0, 0, 0, 0.18);
  margin-left: 46px;
  text-align: center;
  margin-bottom: 27px;
  font-family: 'Ubuntu', sans-serif;
}
.submit {
  cursor: pointer;
  border-radius: 5em;
  color: #fff;
  background: linear-gradient(to right, #f4511e, #e9ac99);
  border: 0;
  padding-left: 40px;
  padding-right: 40px;
  padding-bottom: 10px;
  padding-top: 10px;
  font-family: 'Ubuntu', sans-serif;
  margin-left: 35%;
  font-size: 13px;
  box-shadow: 0 0 20px 1px rgba(0, 0, 0, 0.04);
}
.submit:hover{
  transform: scale(1.05) perspective(1px)
}
.validation-info{
  font-size: 12px;
  color: red;
  text-align: center;
}
</style>
