<template>
  <div class="admin-content">
    <p>Please select a Page</p>
    <ul class="list-group">
      <router-link tag="li" :to="{ name: 'PageDetail', params: { id: page.ID} }"
                   class="list-group-item" style="cursor: pointer"
                   v-for="page in pages">
        {{page.HeaderTitle}}
      </router-link>
    </ul>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';

  export default {
    name: "PageStart",
    computed: {
      ...mapGetters(['pages', 'activePages', 'inactivePages'])
    },
    methods: {
      ...mapActions(['setPages'])
    },
    created: function () {
      this.setPages();
    }
  }
</script>
