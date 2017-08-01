<template>
  <div>
    <md-toolbar>
      <div class="md-toolbar-container">
        <md-button class="md-icon-button" @click="$refs.sidebar.toggle()">
          <md-icon>menu</md-icon>
        </md-button>
        <h2 class="md-title">{{meta.name}}</h2>
      </div>
    </md-toolbar>
    <md-sidenav class="md-left md-fixed" ref="sidebar">
      <md-toolbar class="md-account-header">
        <h3 class="md-title"></h3>
      </md-toolbar>
  
      <md-list>
        <md-list-item @click="goTo('/')" class="md-primary">
          <md-icon>home</md-icon>
          <span>Commands</span>
        </md-list-item>
  
        <md-list-item @click="goTo('/listschedules')" class="md-primary">
          <md-icon>schedule</md-icon>
          <span>Schedule</span>
        </md-list-item>
      </md-list>
    </md-sidenav>
  </div>
</template>

<script>
export default {
  data () {
    return {
    }
  },
  created () {
  },
  props: ['meta'],
  methods: {
    goTo (path) {
      this.$refs.sidebar.toggle()
      this.$router.push(path)
    }
  }
}
</script>

<style scoped>

</style>
