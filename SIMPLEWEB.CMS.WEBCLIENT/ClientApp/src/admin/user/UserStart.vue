<template>
  <div class="admin-content">
    <p>Please select a User</p>
    <ul class="list-group">
      <router-link tag="li" :to="{ name: 'UserDetail', params: { id: user.ID} }"
                   class="list-group-item" style="cursor: pointer"
                   v-for="user in users">{{user.FirstName}} {{user.LastName}}</router-link>
    </ul>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';
  
  export default {
    name: "UserStart",
    computed: {
      ...mapGetters(['users', 'activeUsers', 'inactiveUsers'])
    },
    methods: {
      ...mapActions(['setUsers'])
    },
    created: function () {
      this.setUsers();
    }
  }
</script>
