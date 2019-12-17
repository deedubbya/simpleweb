<template>
  <div class="admin-content">
    <form>
      <div class="form-group">
        <label for="inputStatus">Status</label>
        <div>
          <div class="form-check form-check-inline">
            <input class="form-check-input"
                   type="radio"
                   name="inlineRadioOptions"
                   id="inlineRadio1"
                   v-model="user.Status"
                   value="ACTIVE">
            <label class="form-check-label" for="inlineRadio1">Active</label>
          </div>
          <div class="form-check form-check-inline">
            <input class="form-check-input"
                   type="radio"
                   name="inlineRadioOptions"
                   id="inlineRadio2"
                   v-model="user.Status"
                   value="INACTIVE">
            <label class="form-check-label" for="inlineRadio2">InActive</label>
          </div>
        </div>
      </div>
      <div class="form-group">
        <label for="exampleInputFirstName">First Name</label>
        <input type="email"
               class="form-control"
               id="exampleInputFirstName"
               v-model="user.FirstName"
               placeholder="Enter first name">
      </div>
      <div class="form-group">
        <label for="exampleInputLastName">Last Name</label>
        <input type="email"
               class="form-control"
               id="exampleInputLastName"
               v-model="user.LastName"
               placeholder="Enter last name">
      </div>
      <div class="form-group">
        <label for="exampleInputEmail">Email address</label>
        <input type="email"
               class="form-control"
               id="exampleInputEmail"
               v-model="user.EmailAddress"
               placeholder="Enter email">
      </div>
      <div class="form-group">
        <label for="exampleInputPassword">Password</label>
        <input type="password"
               class="form-control"
               id="exampleInputPassword"
               v-model="user.Password"
               placeholder="Password">
      </div>
      <button type="submit"
              class="btn btn-primary"
              @click.prevent="submit">Submit</button>
    </form>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';

  export default {
    name: 'UserEdit',
    data: function() {
      return {
        confirmed: false
      }
    },
    computed: {
      ...mapGetters(['user'])
    },
    methods: {
      ...mapActions(['setUser', 'updateUser']),
      submit() {
        this.updateUser(this.user)
          .then(response => {
            this.confirmed = true;
            this.$router.push({
              name: 'UserDetail',
              params: { id: this.user.ID }
            });
          }, error => { console.log(error); });
      }
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
      this.setUser(this.$route.params.id);
    }
  }
</script>
