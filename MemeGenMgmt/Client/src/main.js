// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import VueResource from 'vue-resource'

Vue.use(VueResource)
Vue.http.options.root = 'https://localhost:5001'

// log every request and response
Vue.http.interceptors.push((request, next) => {
  console.log(request)
  next(response => {
    console.log(response)
  })
})

Vue.config.productionTip = false
/* eslint-disable no-new */
new Vue({
  el: '#app',
  components: { App },
  template: '<App/>'
})
