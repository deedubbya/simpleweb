import Vue from 'vue';

export default {
  getUsers() {
    return Vue.http.get('User/GetUsers');
  },
  getUser(id) {
    return Vue.http.get(`User/GetUserByID/${id}`);
  },
  addUser(user) {
    return Vue.http.post('User/AddUser', user, { emulateJson: true });
  },
  updateUser(user) {
    return Vue.http.put('User/UpdateUser', user, { emulateJson: true });
  }
}
