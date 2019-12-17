import Vue from 'vue';

export const loadData = async ({ commit }) => {
  await Vue.http.get('User/GetUsers')
    .then(response => response.json())
    .then(data => {
      if (data) {
        commit('SET_USERS', data);
      }
    });

  await Vue.http.get('Menu/GetMenus')
    .then(response => response.json())
    .then(data => {
      if (data) {
        commit('SET_MENUS', data);
      }
    });

  await Vue.http.get('Page/GetPages')
    .then(response => response.json())
    .then(data => {
      if (data) {
        commit('SET_PAGES', data);
      }
    });
};
