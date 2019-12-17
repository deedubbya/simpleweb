<template>
  <div class="admin-content">
    <p>Please select a Menu</p>
    <ul class="list-group">
      <router-link tag="li" :to="{ name: 'MenuDetail', params: { id: menu.ID} }"
                   class="list-group-item" style="cursor: pointer"
                   v-for="menu in menus">
        {{menu.Name}}
      </router-link>
    </ul>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';

  export default {
    name: "MenuStart",
    computed: {
      ...mapGetters(['menus', 'activeMenus', 'inactiveMenus'])
    },
    methods: {
      ...mapActions(['setMenus'])
    },
    created: function () {
      this.setMenus();
    }
  }
</script>
