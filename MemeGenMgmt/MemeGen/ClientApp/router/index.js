import Vue from 'vue'
import Router from 'vue-router'
import AppRoot from '../components/app-root'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'AppRoot',
      component: AppRoot
    }
  ],
  mode: 'history'
})
