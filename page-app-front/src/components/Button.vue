<template>
    <button
      @click="($route.name === 'Studenti') || ($route.name === 'Distudent') ?
              $router.push('/studenti/dodaj-izmjeni') :
              $router.push('/kursevi/dodaj-izmjeni')"
      :type="tip"
      class="btn">
        {{text}}
    </button>
</template>

<script>
export default {
  name: 'Button',
  props: {
    text: String,
    tip: String
  }
}
</script>

<style scoped>
.btn {
  margin: 5px;
  float: right;
  font-size: 16px;
  background-color: #04AA6D;
  color: white;
  padding: 12px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

.btn:hover {
  background-color: #45a049;
}
</style>
