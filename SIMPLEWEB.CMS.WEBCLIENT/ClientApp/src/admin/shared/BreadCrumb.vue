<template>
  <nav aria-label="breadcrumb" v-if="links.length > 1">
    <ol class="breadcrumb">
      <router-link tag="li"
                   class="breadcrumb-item"
                   :to="link.href"
                   active-class="active"
                   :aria-current="$route.path == link.href ? 'page' : 'false'"
                   v-for="link in links">
                      <a v-if="!($route.path == link.href)">{{ link.name }}</a>
                      <span v-else>{{ link.name }}</span>
      </router-link>
    </ol>
  </nav>  
</template>
<script>
  export default {
    name: "BreadCrumb",
    props: ['links']
  }
</script>
<style scoped>
  .breadcrumb > li + li:before {
    color: #ccc;
    content: ">";
    padding: 0 5px;
  }
</style>
