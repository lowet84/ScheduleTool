<template>
  <div>
    <side-menu :meta="{name: 'Editing command'}"></side-menu>
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
        <md-button class="md-raised md-accent" @click="remove">Delete</md-button>
      </md-list-item>
    </md-list>
  </div>
</template>

<script>
import SideMenu from '@/components/Menu'
/* global __api__ */
export default {
  components: {
    SideMenu
  },
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
    },
    async remove () {
      await this.axios.delete(__api__ + '/api/command/' + this.id)
      this.$router.push('/')
    }
  }
}
</script>

<style scoped>

</style>
