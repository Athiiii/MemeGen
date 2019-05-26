import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex)

// TYPES
const MAIN_SET_COUNTER = 'MAIN_SET_COUNTER';

export default new Vuex.Store({
  state: {
    counter: 1
  },
  getters: {
    doubleCounter: state => {
      return state.counter + 1
    }
  },
  mutations: {
    [MAIN_SET_COUNTER] (state, obj) {
      state.counter = obj.counter
    }
  },
  actions: {
    setCounter ({ commit }, obj) {
      commit(MAIN_SET_COUNTER, obj)
    }
  }
})
