import Vue from 'vue'
import Router from 'vue-router'
import appSampleDisplay from '../components/appSampleDisplay'
import appApi from '../components/api/appApi'
import appProfile from '../components/profile/appProfile'
import appLogin from '../components/login/appLogin'
import appMemeCreator from '../components/creator/appMemeCreator'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: appSampleDisplay
    },
    {
      path: '/developer/api',
      component: appApi
    },
    {
      path: '/profile',
      component: appProfile
    },
    {
      path: '/login',
      component: appLogin
    },
    {
      path: '/create',
      component: appMemeCreator
    }
  ],
  mode: 'history'
})
