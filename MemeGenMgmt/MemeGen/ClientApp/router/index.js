import Vue from 'vue';
import Router from 'vue-router';
import appSampleDisplay from '../components/appSampleDisplay';
import appApi from '../components/api/appApi';
import appProfile from '../components/profile/appProfile';
import appRegister from '../components/login/appRegister';
import appLogin from '../components/login/appLogin';
import appMemeCreator from '../components/creator/appMemeCreator';

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
      path: '/register',
      component: appRegister
    },
    {
      path: '/create',
      component: appMemeCreator
    },
    {
      path: '/login',
      component: appLogin
    }
  ],
  mode: 'history'
})
