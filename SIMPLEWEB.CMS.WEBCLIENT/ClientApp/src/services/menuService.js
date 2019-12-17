import Vue from 'vue';

export default {
  getMenus() {
    return Vue.http.get('Menu/GetMenus');
  },
  getMenu(id) {
    return Vue.http.get(`Menu/GetMenuByID/${id}`);
  },
  addMenu(menu) {
    return Vue.http.post('Menu/AddMenu', menu, { emulateJson: true });
  },
  updateMenu(menu) {
    return Vue.http.put('Menu/UpdateMenu', menu, { emulateJson: true });
  },
  updateMenuNavigationItem(menuNavigationItem) {
    return Vue.http.put('Menu/UpdateMenuNavigationItem', menuNavigationItem, { emulateJson: true });
  }
}
