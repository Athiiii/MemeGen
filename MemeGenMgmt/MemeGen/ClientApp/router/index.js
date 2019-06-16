import Vue from 'vue';
import Router from 'vue-router';
import appSampleDisplay from '../components/appSampleDisplay';
import appApi from '../components/api/appApi';
import appProfile from '../components/profile/appProfile';
import appRegister from '../components/login/appRegister';
import appLogin from '../components/login/appLogin';
import appPrivacyPolicy from '../components/agb/appPrivacyPolicy';
import appTermsOfUse from '../components/agb/appTermsOfUse';
import appCreateMeme from '../components/create/appCreateMeme';

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
      path: '/login',
      component: appLogin
    },
    {
      path: '/privacy',
      component: appPrivacyPolicy
    },
    {
      path: '/terms',
      component: appTermsOfUse
    },
    {
      path: '/memeCreate',
      component: appCreateMeme
    }
  ],
  mode: 'history'
})
