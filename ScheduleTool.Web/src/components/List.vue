<template>
  <md-toolbar>
    <h1 class="md-title">Commands</h1>
  </md-toolbar>
</template>

<script>
/* global __api__ */
export default {
  data () {
    return {
      commands: []
    }
  },
  created () {
    this.getCommands()
  },
  methods: {
    async getCommands () {
      let commands = (await this.axios.get(__api__ + '/api/command')).data
      for (var prop in commands) {
        this.commands.push({ name: commands[prop], id: prop })
      }
      console.log(this.commands)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
