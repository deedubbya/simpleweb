<template>
  <div class="admin-content">
    <dl class="row">
      <dt class="col-sm-3">ID:</dt>
      <dd class="col-sm-9">{{ page.ID }}</dd>
      <dt class="col-sm-3">Status:</dt>
      <dd class="col-sm-9">{{ page.Status }}</dd>
      <dt class="col-sm-3">Home Page:</dt>
      <dd class="col-sm-9">{{ page.IsHomePage }}</dd>
      <dt class="col-sm-3">Title:</dt>
      <dd class="col-sm-9">{{ page.HeaderTitle }}</dd>
      <dt class="col-sm-3">Visibility:</dt>
      <dd class="col-sm-9">{{ page.Visibility }}</dd>
    </dl>
    <router-link :to="{ name: 'PageEdit', params: { id: $route.params.id }}" class="btn btn-primary">Edit Page</router-link>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';

  export default {
    name: 'PageDetail',
    computed: {
      ...mapGetters(['page'])
    },
    methods: {
      ...mapActions(['setPage'])
    },
    created() {
      this.setPage(this.$route.params.id);
    }
  }
</script>
