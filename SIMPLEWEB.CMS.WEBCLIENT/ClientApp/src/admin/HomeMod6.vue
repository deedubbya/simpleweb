<template>
  <div class="container">
    <div class="row">
      <div class="col-xs-12 col-sm-8 col-sm-offset-2 col-md-6 col-md-offset-3">
        <div class="form-group">
          <label>First Name</label>
          <input class="form-control" type="text" v-model="UserViewModel.FirstName" />
        </div>
        <div class="form-group">
          <label>Last Name</label>
          <input class="form-control" type="text" v-model="UserViewModel.LastName" />
        </div>
        <div class="form-group">
          <label>Mail</label>
          <input class="form-control" type="text" v-model="UserViewModel.EmailAddress" />
        </div>
        <div class="form-group">
          <label>Password</label>
          <input class="form-control" type="password" v-model="UserViewModel.Password" />
        </div>
        <div class="form-group">
          <label>Status</label>
          <input type="radio" id="active" value="ACTIVE"
                 v-model="UserViewModel.Status" /> Active
          <input type="radio" id="inactive" value="INACTIVE"
                 v-model="UserViewModel.Status" /> InActive
        </div>
        <button class="btn btn-primary" @click.prevent="submit()">Submit</button>
        <hr />
        <button class="btn btn-primary" @click.prevent="getdata()">Get User</button>
        <hr />
        <button class="btn btn-primary" @click.prevent="getUsers()">Get User List</button>
        <ul>
          <li v-for="user in users">
            {{user.FirstName}} {{user.LastName}}
            <ul>
              <li>Status: {{ user.Status }}</li>
              <li>Email: {{ user.EmailAddress }}</li>
              <li>Password: {{ user.Password }}</li>
            </ul>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>
<script>
  export default {
    data() {
      return {
        UserViewModel: {
          Status: 'ACTIVE',
          FirstName: '',
          LastName: '',
          EmailAddress: '',
          Password: ''
        },
        users: [],
        http: {}
      }
    },
    computed: {
      userJson() {
        return JSON.parse(JSON.stringify(this.UserViewModel));
      }
    },
    methods: {
      getUsers() {
        this.http.getUsers()
          .then(response => { this.users = response.data; }, error => { console.log(error); });
      },
      getdata() {
        this.http.getUser({ id: 1 })
          .then(response => { this.UserViewModel = response.data; }, error => { console.log(error); });
      },
      submit() {
        this.http.addUser(this.userJson);
      }
    },
    created() {
      const customActions = {
        getUsers: { method: 'GET', url: 'User/GetUsers' },
        getUser: { method: 'GET', url: 'User/GetUserByID{/id}' },
        addUser: { method: 'POST', url: 'User/AddUser' }
      };
      this.http = this.$resource('userdata', {}, customActions);
      console.log(this.http);
    }
  }
</script>
<style>
</style>
