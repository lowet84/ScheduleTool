<template>
  <div>
    <side-menu :meta="{name: 'Commands'}"></side-menu>
      <md-list>
        <md-list-item v-for="command in commands" :key="command.id">
          <md-button class="md-icon-button md-list-action" @click="run(command.id)">
            <md-icon class="md-primary">play_arrow</md-icon>
          </md-button>
          <span>{{command.name}}</span>
          <md-button class="md-icon-button md-list-action" @click="edit(command.id)">
            <md-icon class="md-primary">edit</md-icon>
          </md-button>
  
        </md-list-item>
      </md-list>
      <md-button class="md-fab md-fab-bottom-right" @click="add">
        <md-icon>add</md-icon>
      </md-button>
  </div>
</template>

<script>
import SideMenu from '@/components/Menu'
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
  components: {
    SideMenu
  },
  methods: {
    async getCommands () {
      let commands = (await this.axios.get(__api__ + '/api/command')).data
      let list = []
      for (var prop in commands) {
        list.push({ name: commands[prop], id: prop })
      }
      list = list.sort((a, b) => {
        var textA = a.name.toUpperCase()
        var textB = b.name.toUpperCase()
        return (textA < textB) ? -1 : (textA > textB) ? 1 : 0
      })
      this.commands = list
    },
    edit (id) {
      this.$router.push('/editcommand/' + id)
    },
    async add () {
      let id = (await this.axios.post(__api__ + '/api/command', { name: 'New' })).data
      this.$router.push('/editcommand/' + id)
    },
    run (id) {
      this.$router.push('/run/' + id)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
