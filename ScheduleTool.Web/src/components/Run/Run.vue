<template>
  <div>
    <md-toolbar>
      <h1 class="md-title">Run</h1>
    </md-toolbar>
    <md-subheader>Output</md-subheader>
    <p class="result">{{result}}</p>
  </div>
</template>

<script>
/* global __api__ */
export default {
  data () {
    return {
      result: null
    }
  },
  props: ['id'],
  created () {
    this.run()
  },
  methods: {
    async run () {
      let result = await this.axios.get(__api__ + '/api/run/' + this.id)
      this.result = result.data
      console.log(this.result)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.result {
  white-space: pre-wrap;
  padding: 16px;
}
</style>
