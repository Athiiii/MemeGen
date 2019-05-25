import Vue from 'vue'
import Router from 'vue-router'
import appSampleDisplay from '../components/appSampleDisplay'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: appSampleDisplay
    }
  ],
  mode: 'history'
})
