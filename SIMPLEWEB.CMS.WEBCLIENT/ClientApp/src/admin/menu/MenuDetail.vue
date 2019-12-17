<template>
  <div class="admin-content">
    <dl class="row">
      <dt class="col-sm-3">ID:</dt>
      <dd class="col-sm-9">{{ menu.ID }}</dd>
      <dt class="col-sm-3">Name:</dt>
      <dd class="col-sm-9">{{ menu.Name }}</dd>
    </dl>
    <router-link :to="{ name: 'MenuEdit', params: { id: $route.params.id }}" class="btn btn-primary">Edit Menu</router-link>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';

  export default {
    name: 'MenuDetail',
    computed: {
      ...mapGetters(['menu'])
    },
    methods: {
      ...mapActions(['setMenu'])
    },
    created() {
      this.setMenu(this.$route.params.id);
    }
  }
</script>
