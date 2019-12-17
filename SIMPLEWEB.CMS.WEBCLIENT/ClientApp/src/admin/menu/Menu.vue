<template>
  <div class="admin-section">
    <h2>Menus</h2>
    <app-breadcrumb :links="links"></app-breadcrumb>
    <router-view></router-view>
  </div>
</template>
<script>
  import Breadcrumb from '../shared/BreadCrumb';

  export default {
    name: "Menu",
    data() {
      return {
        links: []
      }
    },
    watch: {
      $route(to, from) {
        this.buildLinkList();
        if (to) {
          if (to.name == 'MenuDetail' || to.name == 'MenuEdit') {
            this.links.push({
              name: 'Menu Detail',
              href: '/menu/detail/' + this.$route.params.id
            });
          }
          if (to.name == 'MenuEdit') {
            this.links.push({
              name: 'Menu Edit',
              href: '/menu/edit/' + this.$route.params.id
            });
          }
        }
      }
    },
    methods: {
      buildLinkList: function () {
        let linkList = [
          {
            name: 'Menu',
            href: '/menu'
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
