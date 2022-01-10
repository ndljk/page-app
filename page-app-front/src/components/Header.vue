<template>
  <div class="topnav" v-if="$route.name!=='Prijava'" >
    <router-link
      :class="($route.name=== 'Studenti')
        || ($route.name==='Distudent')
        || ($route.name==='StudentDetalji') ? 'aktivanNav':''"
      to="/studenti">Studenti
    </router-link>
    <router-link
      :class="($route.name==='Kursevi')
        || ($route.name==='Dikurs')
        || ($route.name==='KursDetalji') ? 'aktivanNav':''"
      to="/kursevi">Kursevi
    </router-link>
    <button class="button"
        @click="odjava">
        <span>Odjava </span>
    </button>
  </div>
  <router-view/>
</template>

<script>
export default {
  name: 'Header',
  methods: {
    odjava () {
      this.$router.push('/prijava')
      localStorage.setItem('token', '')
    }
  }
}
</script>

<style scoped>

.topnav {
  background-color: #333;
  overflow: hidden;
}

.aktivanNav {
  border-bottom: 3px solid #ddd;
}
.topnav a {
  float: left;
  color: #f2f2f2;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
}

.topnav a:hover {
  background-color: #ddd;
  color: black;
  border-bottom: 3px solid #ddd;
}

.button {
  border-radius: 4px;
  background: linear-gradient(to right, #f4511e, #e9ac99);
  border: none;
  color: #FFFFFF;
  text-align: center;
  font-size: 17px;
  padding: 10px;
  width: 120px;
  transition: all 0.5s;
  cursor: pointer;
  margin: 5px;
  float: right;
}

.button span {
  cursor: pointer;
  display: inline-block;
  position: relative;
  transition: 0.5s;
}

.button span:after {
  content: '\00bb';
  position: absolute;
  opacity: 0;
  top: 0;
  right: -20px;
  transition: 0.5s;
}

.button:hover span {
  padding-right: 25px;
}

.button:hover span:after {
  opacity: 1;
  right: 0;
}
</style>
