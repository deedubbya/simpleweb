<template>
  <div class="admin-section">
    <h2>Pages</h2>
    <app-breadcrumb :links="links"></app-breadcrumb>
    <router-view></router-view>
  </div>
</template>
<script>
  import Breadcrumb from '../shared/BreadCrumb'

  export default {
    name: "Page",
    data() {
      return {
        links: []
      }
    },
    watch: {
      $route(to, from) {
        this.buildLinkList();
        if (to) {
          if (to.name == 'PageDetail' || to.name == 'PageEdit') {
            this.links.push({
              name: 'Page Detail',
              href: '/page/detail/' + this.$route.params.id
            });
          }
          if (to.name == 'PageEdit') {
            this.links.push({
              name: 'Page Edit',
              href: '/page/edit/' + this.$route.params.id
            });
          }
        }
      }
    },
    methods: {
      buildLinkList: function () {
        let linkList = [
          {
            name: 'Page',
            href: '/page'
          }
        ];
        this.links = linkList;
      }
    },
    components: {
      'app-breadcrumb': Breadcrumb
    },
    created() {
      this.buildLinkList();
    }
  }
</script>
