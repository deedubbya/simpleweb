import Vue from 'vue';

export default {
  getPages() {
    return Vue.http.get('Page/GetPages');
  },
  getPage(id) {
    return Vue.http.get(`Page/GetPageByID/${id}`);
  },
  addPage(page) {
    return Vue.http.post('Page/AddPage', page, { emulateJson: true });
  },
  updatePage(page) {
    return Vue.http.put('Page/UpdatePage', page, { emulateJson: true });
  }
}
