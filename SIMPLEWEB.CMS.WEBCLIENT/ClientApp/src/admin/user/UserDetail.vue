<template>
  <div class="admin-content">
    <dl class="row">
      <dt class="col-sm-3">ID:</dt>
      <dd class="col-sm-9">{{ user.ID }}</dd>
      <dt class="col-sm-3">Status:</dt>
      <dd class="col-sm-9">{{ user.Status }}</dd>
      <dt class="col-sm-3">First Name:</dt>
      <dd class="col-sm-9">{{ user.FirstName }}</dd>
      <dt class="col-sm-3">Last Name:</dt>
      <dd class="col-sm-9">{{ user.LastName }}</dd>
      <dt class="col-sm-3">Email:</dt>
      <dd class="col-sm-9">{{ user.EmailAddress }}</dd>
      <dt class="col-sm-3">Password:</dt>
      <dd class="col-sm-9">{{ user.Password }}</dd>
    </dl>
    <router-link :to="{ name: 'UserEdit', params: { id: $route.params.id }}" class="btn btn-primary">Edit User</router-link>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';

  export default {
    name: 'UserDetail',
    computed: {
      ...mapGetters(['user'])
    },
    methods: {
      ...mapActions(['setUser'])
    },
    created() {
      this.setUser(this.$route.params.id);
    }
  }
</script>
