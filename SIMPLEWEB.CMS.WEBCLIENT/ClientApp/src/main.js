import Vue from 'vue';
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import VueQuillEditor from 'vue-quill-editor'
import 'quill/dist/quill.core.css'
import 'quill/dist/quill.snow.css'
import 'quill/dist/quill.bubble.css'


import VueResource from 'vue-resource';
import router from './router/router';
import store from './store/store';
import app from './App';

Vue.config.productionTip = false;

Vue.use(VueQuillEditor)

Vue.use(BootstrapVue);

Vue.use(VueResource);

Vue.http.options.root = 'https://localhost:44392/api';

Vue.http.interceptors.push((request, next) => {
  //console.log(request);
  next(response => {
    //console.log(response);
  });
});

new Vue({
  el: '#app',
  router,
  store,
  render: h => h(app),
  created() {
    store.dispatch('setMenus');
    store.dispatch('setPages');
  }
});
