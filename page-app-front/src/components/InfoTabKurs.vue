<template>
  <div class="infotab">
    <h4>{{infotab.naziv}}</h4>
    <div>
        <button
          @click="$router.push('/kursevi/detalji/' + infotab.id)"
          class="btn btn-info">
          <i class="fa fa-info"></i>
        </button>
        <button class="btn btn-edit"><i class="fa fa-pencil"></i></button>
        <button
          @click="$emit('delete-emit', infotab.id)"
          class="btn btn-trash">
          <i class="fa fa-trash"></i>
        </button>
    </div>
  </div>
</template>

<script>
export default {
  name: 'InfoTab',
  props: {
    infotab: Object
  },
  emits: ['delete-emit']
}
</script>

<style scoped>
.infotab {
  background: #f4f4f4;
  margin: 5px 30%;
  padding: 10px 20px;
  display:flex;
  justify-content:space-between;
  vertical-align: middle;
  border-left: 5px solid #04AA6D
}
.btn{
  background-color: #ddd;
  border: none;
  color: black;
  padding: 10px 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  margin: 4px 2px;
  cursor: pointer;
  border-radius: 16px;
}
.btn.btn-info{
    color:white;
}
.btn.btn-edit{
    color:white;
    background-color: dodgerblue;
}
.btn.btn-trash{
    color:white;
    background-color: red;
}
.btn:hover{
    transform: scale(1.05) perspective(1px);
    color: black;
}

</style>
