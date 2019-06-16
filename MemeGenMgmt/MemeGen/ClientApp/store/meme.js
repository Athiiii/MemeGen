const state = {
  templateImg: null
}

const mutations = {
  setTemplate (states, img) {
    states.templateImg = img
  }
}

export default {
  state,
  mutations
}
