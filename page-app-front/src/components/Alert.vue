<template>
    <div :class="boja" v-if="this.display">
        {{ alertText }}
        <span class="closebtn" @click="sakrijAlert">&times;</span>
    </div>
</template>

<script>
export default {
  name: 'Alert',
  props: {
    alertText: String,
    boja: String
  },
  data () {
    return {
      display: true
    }
  },
  methods: {
    sakrijAlert () {
      this.display = !this.display
    }
  },
  created () {
    setTimeout(() => { this.display = false }, 3000)
  }
}
</script>

<style scoped>
.alert {
  padding: 20px;
  background-color: #f44336;
  color: white;
  margin-bottom: 15px;
  margin-left: 10px;
  margin-right: 10px;
  margin-top: 5px;
  border-radius: 5px;
}
.success {
  padding: 20px;
  background-color: #04AA6D;
  color: white;
  margin-bottom: 15px;
  margin-left: 10px;
  margin-right: 10px;
  margin-top: 5px;
  border-radius: 5px;
}
.closebtn {
  margin-left: 15px;
  color: white;
  font-weight: bold;
  float: right;
  font-size: 22px;
  line-height: 20px;
  cursor: pointer;
  transition: 0.3s;
}
.closebtn:hover {
  color: black;
}
</style>
