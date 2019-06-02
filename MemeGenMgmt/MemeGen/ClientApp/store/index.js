import Vue from 'vue';
import Vuex from 'vuex';
import login from './login';

Vue.use(Vuex)

const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER';

export default new Vuex.Store({
  state: {
    counter: 0,
    darkmode: false
  },
  getters: {
    doubleCounter: state => {
      return state.counter + 1
    }
  },
  mutations: {
    [MAIN_SET_COUNTER] (state, obj) {
      state.counter = obj.counter
    },
    initialiseStore (state) {
      debugger
      if (localStorage.getItem('store')) {
        this.replaceState(
          Object.assign(state, JSON.parse(localStorage.getItem('store')))
        )
      }
    },
    switchDarkmode (state) {
      state.darkmode = !state.darkmode
    }
  },
  actions: {
    setCounter ({ commit }, obj) {
      commit(MAIN_SET_COUNTER, obj)
    }
  },
  modules: {
    login
  }
})
