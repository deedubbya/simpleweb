import Vue from 'vue';
import service from '../../services/menuService';

const state = {
  menu: {},
  menus: []
};

const getters = {
  menu: state => state.menu,
  menus: state => state.menus,
  activeMenus: state => state.menus.filter(menu => menu.Status == 'ACTIVE'),
  inactiveMenus: state => state.menus.filter(menu => menu.Status == 'INACTIVE')
};

const mutations = {
  'SET_MENUS'(state, menus) {
    state.menus = menus;
  },
  'SET_MENU'(state, menu) {
    state.menu = menu;
  },
  'ADD_MENU'(state, menu) {
    state.menus.push(menu);
  },
  'UPDATE_MENU'(state, menu) {
    state.menu = menu;
  }
};

const actions = {    
  setMenus: async ({ commit }) => {
    await service.getMenus()
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('SET_MENUS', data);
          commit('SET_MENU', data[0]);
        }
    });
  },
  setMenu: async ({ commit }, id) => {
    await service.getMenu(id)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('SET_MENU', data);
        }
      });
  },
  addMenu: async ({ commit }, menu) => {
    await service.addMenu(menu)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('ADD_MENU', menu);
        }
    });
  },
  updateMenu: async ({ commit }, menu) => {
    await service.updateMenu(menu)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('UPDATE_MENU', menu);
        }
    });
  }
};

export default {
  state,
  getters,
  mutations,
  actions
};
