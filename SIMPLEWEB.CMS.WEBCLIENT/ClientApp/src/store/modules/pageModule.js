import Vue from 'vue';
import service from '../../services/pageService';

const state = {
  page: {},
  pages: []
};

const getters = {
  page: state => state.page,
  pages: state => state.pages,
  activePages: state => state.pages.filter(page => page.Status == 'ACTIVE'),
  inactivePages: state => state.pages.filter(page => page.Status == 'INACTIVE')
};

const mutations = {
  'SET_PAGES'(state, pages) {
    state.pages = pages;
  },
  'SET_PAGE'(state, page) {
    console.log(page);
    state.page = page;
  },
  'ADD_PAGE'(state, page) {
    state.pages.push(page);
  },
  'UPDATE_PAGE'(state, page) {
    state.page = page;
  }
};

const actions = {
  setPages: async ({ commit }) => {
    await service.getPages()
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('SET_PAGES', data);
        }
    });
  },
  setPage: async ({ commit }, id) => {
    await service.getPage(id)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('SET_PAGE', data);
        }
      });
  },
  addPage: async ({ commit }, page) => {
    await service.addPage(page)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('ADD_PAGE', page);
        }
    });
  },
  updatePage: async ({ commit }, page) => {
    await service.updatePage(page)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('UPDATE_PAGE', page);
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
