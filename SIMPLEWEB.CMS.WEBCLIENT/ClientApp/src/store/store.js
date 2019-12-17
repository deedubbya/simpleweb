import Vue from 'vue';
import Vuex from 'vuex';
import userObj from './modules/userModule';
import menuObj from './modules/menuModule';
import pageObj from './modules/pageModule';
import * as actions from './actions';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    adminDirectory: 'admin'
  },
  actions,
  modules: { userObj, menuObj, pageObj }
});
