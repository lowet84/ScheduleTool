import Vue from 'vue'
import Router from 'vue-router'

// Commands
import ListCommands from '@/components/Commands/ListCommands'
import EditCommand from '@/components/Commands/EditCommand'

import ListSchedules from '@/components/Schedule/ListSchedules'
import EditSchedule from '@/components/Schedule/EditSchedule'

// Run
import Run from '@/components/Run/Run'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'ListCommands',
      component: ListCommands
    },
    {
      path: '/editcommand/:id',
      name: 'EditCommand',
      component: EditCommand,
      props: true
    },
    {
      path: '/listschedules/',
      name: 'ListSchedules',
      component: ListSchedules
    },
    {
      path: '/editschedule/:id',
      name: 'EditSchedule',
      component: EditSchedule,
      props: true
    },
    {
      path: '/run/:id',
      name: 'Run',
      component: Run,
      props: true
    }
  ]
})
