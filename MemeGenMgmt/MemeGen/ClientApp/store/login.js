const state = {
  mailRule: [
    value => {
      if (value.length > 0) {
        const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        return pattern.test(value) || 'Invalid e-mail.';
      }
      return 'Email is empty';
    }
  ],
  usernameRule: [
    value => {
      if (value.length === 0) return 'username is empty';
      else return true
    }
  ],
  passwordRule: [
    value => {
      if (value.length === 0) return 'password is empty';
      else if (value.length < 8) return 'password length must be more than 8';
      else if (/(?=.*\d)(?=.*[a-zA-Z])/.test(value)) return true
      else return 'password must contain letters and numbers';
    }
  ],
  agbRule: [value => !!value || 'You must agree to continue!'],
  mail: ''
}

const mutations = {
  setMail (states, mail) {
    states.mail = mail
  }
}

export default {
  state,
  mutations
}
