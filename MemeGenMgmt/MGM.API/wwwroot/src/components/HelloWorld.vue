<template>
  <div class="hello">
    <input placeholder="put any data" v-model="inputData"/>
    <br><br>
    <Button @click="submit">Submit</Button>
    <br><br>
    <p>{{reponse}}</p>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  data () {
    return {
      inputData: '',
      reponse: null
    }
  },
  methods: {
    submit() {
      console.log(JSON.stringify(this.inputData))
      
      this.$http.post('/api/values', `['${this.inputData}']`)
        .then(response => {
          console.log(response)
        }, error => {
          console.log(error)
        })
    }
  }
}
</script>
