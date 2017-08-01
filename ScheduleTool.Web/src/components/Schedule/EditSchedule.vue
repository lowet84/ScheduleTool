<template>
  <div>
    <side-menu :meta="{name: 'Editing schedule'}"></side-menu>
    <md-list v-if="schedule!=null">
      <md-list-item>
        <md-input-container>
          <label>Name</label>
          <md-input required v-model="schedule.name"></md-input>
        </md-input-container>
      </md-list-item>
      <md-list-item>
        <md-input-container>
          <label for="mode">Schedule mode</label>
          <md-select name="mode" id="mode" v-model="schedule.scheduleMode">
            <md-option :value='0'>Initialize once</md-option>
            <md-option :value='1'>Startup</md-option>
            <md-option :value='2'>Every minute</md-option>
            <md-option :value='3'>Every 5 minutes</md-option>
            <md-option :value='4'>Every half hour</md-option>
            <md-option :value='5'>Every hour</md-option>
            <md-option :value='6'>Every six hours</md-option>
            <md-option :value='7'>Every day</md-option>
          </md-select>
        </md-input-container>
      </md-list-item>
      <md-subheader>Selected commands</md-subheader>
      <md-list-item v-for="(command, index) in selectedCommands" :key="command.id">
        <span>{{command.name}}</span>
        <md-button class="md-icon-button md-list-action" @click="removeCommand(index)">
          <md-icon class="md-accent">delete</md-icon>
        </md-button>
      </md-list-item>
      <md-subheader>Available commands</md-subheader>
      <md-list-item v-for="command in commands" :key="command.id">
        <span>{{command.name}}</span>
        <md-button class="md-icon-button md-list-action" @click="addCommand(command)">
          <md-icon class="md-primary">add</md-icon>
        </md-button>
      </md-list-item>
      <md-list-item>
        <md-divider class="md-inset"></md-divider>
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
      schedule: null,
      commands: [],
      selectedCommands: [],
      fruits: ['Orange', 'Apple', 'Pineapple']
    }
  },
  props: ['id'],
  created () {
    this.getData()
  },
  methods: {
    async getData () {
      let schedule = await this.axios.get(__api__ + '/api/schedule/' + this.id)
      this.schedule = schedule.data

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

      if (this.schedule.commands != null) {
        this.selectedCommands = this.schedule.commands
          .map((e) => this.commands.find((f) => f.id === e))
      }
    },
    async save () {
      this.schedule.commands = this.selectedCommands.map((e) => e.id)
      await this.axios.put(__api__ + '/api/schedule/', this.schedule)
      this.$router.push('/listschedules')
    },
    async remove () {
      await this.axios.delete(__api__ + '/api/schedule/' + this.id)
      this.$router.push('/listschedules')
    },
    removeCommand (index) {
      this.selectedCommands.splice(index, 1)
    },
    addCommand (command) {
      if (this.selectedCommands === null) {
        this.selectedCommands = []
      }
      this.selectedCommands.push(command)
    }
  }
}
</script>

<style scoped>

</style>
