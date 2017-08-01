<template>
  <div>
    <side-menu :meta="{name: 'Schedules'}"></side-menu>
    <md-list>
      <md-list-item v-for="schedule in schedules" :key="schedule.id">
        <span>{{schedule.name}}</span>
        <md-button class="md-icon-button md-list-action" @click="edit(schedule.id)">
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
      schedules: []
    }
  },
  created () {
    this.getschedules()
  },
  components: {
    SideMenu
  },
  methods: {
    async getschedules () {
      let schedules = (await this.axios.get(__api__ + '/api/schedule')).data
      let list = []
      for (var prop in schedules) {
        list.push({ name: schedules[prop], id: prop })
      }
      list = list.sort((a, b) => {
        var textA = a.name.toUpperCase()
        var textB = b.name.toUpperCase()
        return (textA < textB) ? -1 : (textA > textB) ? 1 : 0
      })
      this.schedules = list
    },
    edit (id) {
      this.$router.push('/editschedule/' + id)
    },
    async add () {
      let id = (await this.axios.post(__api__ + '/api/schedule', { name: 'New' })).data
      this.$router.push('/editschedule/' + id)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
