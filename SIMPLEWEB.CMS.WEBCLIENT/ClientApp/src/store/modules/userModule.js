import service from '../../services/userService';

const state = {
  user: {},
  users: []
};

const getters = {
  user: state => state.user,
  users: state => state.users,
  activeUsers: state => state.users.filter(user => user.Status == 'ACTIVE'),
  inactiveUsers: state => state.users.filter(user => user.Status == 'INACTIVE')
};

const mutations = {
  'SET_USERS'(state, users) {
    state.users = users;
  },
  'SET_USER'(state, user) {
    state.user = user;
  },
  'ADD_USER'(state, user) {
    state.users.push(user);
  },
  'UPDATE_USER'(state, user) {
    state.user = user;
  }
};

const actions = {
  setUsers: async ({ commit }) => {
    await service.getUsers()
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('SET_USERS', data);
        }
    });
  },
  setUser: async ({ commit }, id) => {
    await service.getUser(id)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('SET_USER', data);
        }
      });
  },
  addUser: async ({ commit }, user) => {
    await service.addUser(user)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('ADD_USER', user);
        }
    });
  },
  updateUser: async ({ commit }, user) => {
    await service.updateUser(user)
      .then(response => response.json())
      .then(data => {
        if (data) {
          commit('UPDATE_USER', user);
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
