<template>
  <div class="nav flex-column nav-pills admin-menu" id="v-pills-tab" role="tablist"
       aria-orientation="vertical">

    <router-link to="/admin/account"
                 class="nav-link"
                 data-toggle="pill"
                 active-class="active">Account</router-link>

    <router-link to="/admin/user"
                 class="nav-link"
                 data-toggle="pill"
                 active-class="active">Users</router-link>

    <router-link to="/admin/menu"
                 class="nav-link"
                 data-toggle="pill"
                 active-class="active">Menus</router-link>

    <router-link to="/admin/page"
                 class="nav-link"
                 data-toggle="pill"
                 active-class="active">Pages</router-link>

    <a href="/admin/account" class="nav-link" data-toggle="pill" active-class="active">Media</a>

  </div>
</template>
<style>
  .admin-menu {
    background-color: #ffffff;
    padding: 30px;
    border-radius: 10px;
  }
</style>
