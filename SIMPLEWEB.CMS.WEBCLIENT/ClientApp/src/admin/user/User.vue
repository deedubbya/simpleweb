<template>
  <div class="admin-section">
    <h2>Users</h2>
    <app-breadcrumb :links="links"></app-breadcrumb>
    <router-view></router-view>
  </div>
</template>
<script>
  import Breadcrumb from '../shared/BreadCrumb'

  export default {
    name: "User",
    data() {
      return {
        links: []
      }
    },
    watch: {
      $route(to, from) {
        this.buildLinkList();
        if (to) {
          if (to.name == 'UserDetail' || to.name == 'UserEdit') {
            this.links.push({
              name: 'User Detail',
              href: '/user/detail/' + this.$route.params.id
            });
          }
          if (to.name == 'UserEdit') {
            this.links.push({
              name: 'User Edit',
              href: '/user/edit/' + this.$route.params.id
            });
          }
        }

        console.log(this.$route.path);
        console.log(this.links);
      }
    },
    methods: {
      buildLinkList: function () {
        let linkList = [
          {
            name: 'Users',
            href: '/user'
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
