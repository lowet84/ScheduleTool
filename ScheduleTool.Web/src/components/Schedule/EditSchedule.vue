<template>
  <div>
    <md-toolbar>
      <h1 class="md-title">Edit schedule</h1>
    </md-toolbar>
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
      schedule: null
    }
  },
  props: ['id'],
  created () {
    this.getschedule()
  },
  methods: {
    async getschedule () {
      let schedule = await this.axios.get(__api__ + '/api/schedule/' + this.id)
      this.schedule = schedule.data
    },
    async save () {
      await this.axios.put(__api__ + '/api/schedule/', this.schedule)
      this.$router.push('/listschedules')
    }
  }
}
</script>

<style scoped>

</style>
