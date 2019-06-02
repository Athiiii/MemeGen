import Vue from 'vue';
import axios from 'axios';
import router from './router/index';
import store from './store';
import { sync } from 'vuex-router-sync';
import App from 'components/app-root';
import { FontAwesomeIcon } from './icons';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';

// Register Vuetify Components
Vue.use(Vuetify)

// Registration of global components
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App,
  beforeCreate () {
    // get data from localstorage
    this.$store.commit('initialiseStore')
  }
})

// Subscribe to store updates
store.subscribe((mutation, state) => {
  console.log('subscribe')
  let store = {
    darkmode: state.darkmode,
    mail: state.login.mail
  }
  // Store the store object as a JSON string
  localStorage.setItem('store', JSON.stringify(store))
})

export { app, router, store }
