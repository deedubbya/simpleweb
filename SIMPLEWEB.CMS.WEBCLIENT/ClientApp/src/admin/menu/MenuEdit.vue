<template>
  <div class="admin-content">
    <form>
      <div class="form-group">
        <label for="InputName">Name</label>
        <input type="text"
               class="form-control"
               id="InputName"
               v-model="menu.Name"
               placeholder="Enter menu name">
      </div>
      <div class="form-group">
        <label for="InputNavItems">Navigation Items</label>
        <div id="InputNavItems">
          <div role="tablist">
            <b-card no-body class="mb-1" v-for="nav in menu.NavigationItems">
              <b-card-header header-tag="header"
                             class="p-1"
                             role="tab"
                             @click="editing = false">
                <b-btn block href="#"
                       class="text-left"
                       v-b-toggle="'accordion' + nav.ID"
                       variant="info"
                       v-text="nav.Title"></b-btn>
              </b-card-header>
              <b-collapse :id="'accordion' + nav.ID" accordion="navAccordion" role="tabpanel">
                <b-card-body>
                  <menu-nav-detail v-if="!editing"
                                   v-on:BeginEdit="editing = true"
                                   :nav="nav"></menu-nav-detail>
                  <menu-nav-edit v-if="editing"
                                 v-on:CancelEdit="editing = false"
                                 v-on:HandleSave="saveNavItem"
                                 :nav="nav"></menu-nav-edit>
                </b-card-body>
              </b-collapse>
            </b-card>     
          </div>
        </div>
      </div>
      <button type="submit"
              class="btn btn-primary"
              @click.prevent="submit">
        Submit
      </button>
    </form>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';
  import MenuNavDetail from './menunav/MenuNavDetail';
  import MenuNavEdit from './menunav/MenuNavEdit';

  export default {
    name: 'MenuEdit',
    data: function () {
      return {
        confirmed: false,
        editing: false
      }
    },
    computed: {
      ...mapGetters(['menu'])
    },
    methods: {
      ...mapActions(['setMenu', 'updateMenu', 'updateMenuNavigationItem']),
      saveNavItem(ev) {
        this.updateMenuNavigationItem(ev)
          .then(response => {
            this.setMenu(this.$route.params.id);
            this.editing = false;
          }, error => { console.log(error); });
      },
      submit() {
        this.updateMenu(this.menu)
          .then(response => {
            this.confirmed = true;
            this.$router.push({
              name: 'MenuDetail',
              params: { id: this.menu.ID }
            });
          }, error => { console.log(error); });
      }
    },
    components: {
      'menu-nav-detail': MenuNavDetail,
      'menu-nav-edit': MenuNavEdit
    },
    beforeRouteLeave(to, from, next) {
      if (this.confirmed) {
        next();
      }
      else {
        next(confirm('Are you sure?'));
      }
    },
    created() {
      this.setMenu(this.$route.params.id);
    }
  }
</script>
