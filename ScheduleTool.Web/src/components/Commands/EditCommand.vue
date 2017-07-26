<template>
  <div>
    <md-toolbar>
      <h1 class="md-title">Edit command</h1>
    </md-toolbar>
    <md-list v-if="command!=null">
      <md-list-item>
        <md-input-container>
          <label>Name</label>
          <md-input required v-model="command.name"></md-input>
        </md-input-container>
      </md-list-item>
      <md-list-item>
        <md-input-container>
          <label>Application</label>
          <md-input required v-model="command.application"></md-input>
        </md-input-container>
      </md-list-item>
      <md-list-item>
        <md-input-container>
          <label>Arguments</label>
          <md-input v-model="command.arguments"></md-input>
        </md-input-container>
      </md-list-item>
      <md-list-item>
        <md-input-container>
          <label>Working directory</label>
          <md-input v-model="command.workDir"></md-input>
        </md-input-container>
      </md-list-item>
      <md-list-item>
        <md-button class="md-raised md-primary" @click="save">Save</md-button>
      </md-list-item>
    </md-list>
  </div>
</template>

<script>
/* global __api__ */
export default {
  data () {
    return {
      command: null
    }
  },
  props: ['id'],
  created () {
    this.getCommand()
  },
  methods: {
    async getCommand () {
      let command = await this.axios.get(__api__ + '/api/command/' + this.id)
      this.command = command.data
    },
    async save () {
      await this.axios.put(__api__ + '/api/command/', this.command)
      this.$router.push('/')
    }
  }
}
</script>

<style scoped>

</style>
