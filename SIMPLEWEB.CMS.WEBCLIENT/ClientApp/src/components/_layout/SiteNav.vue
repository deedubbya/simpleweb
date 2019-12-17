<template>
  <div id="nav" class="row">
    <ul v-if="menu != null">
      <li v-for="nav in menu.NavigationItems">
        <router-link v-if="nav.LinkType == 'PAGE'"
                     :to="nav.PageUrl"
                     class="nav-link"
                     active-class="active">{{ nav.Title }}</router-link>
        <a v-if="nav.LinkType == 'EXTERNAL'"
           :href="nav.ExternalLink"
           target="_blank"
           class="nav-link">{{ nav.Title }}</a>
      </li>
    </ul>
  </div>
  <!--
  public int ID { get; set; }
         public int MenuID { get; set; }
         public int MenuHeirarchy { get; set; }
         public int MenuSort { get; set; }
         public string LinkType { get; set; }
         public int? PageID { get; set; }
         public PageViewModel Page { get; set; }
         public string ExternalLink { get; set; }
         public string Title { get; set; }


        public int ID { get; set; }
        public string Status { get; set; }
        public bool IsHomePage { get; set; }
        public string Visibility { get; set; }
        public string HeaderTitle { get; set; }
        public string HtmlContent { get; set; }
      -->
</template>
<script>
  import { mapGetters } from 'vuex';

  export default {
    name: "SiteNav",
    computed: {
      ...mapGetters(['menus', 'pages']),
      menu: function () {
        let m = this.menus.filter(m => {
          return m.ID === 1;
        })[0];
        console.log("menu");
        console.log(m);
        return m;
      }
    }
  }
</script>
<style scoped>
  #nav {
    margin: 0px 25px;
    border: 3px solid #164871;
    background-color: #a5cae5;
    padding: 0px 5px 3px 1px;
  }

  #nav ul {
    margin-bottom:0px;
  }

  #nav li {
    display: inline;
    background-color: #245882;
    width: 120px;
    height: 22px;
    float: left;
    margin: 3px 0px 0px 4px;
    text-align: center;
  }

  #nav a {
    width: 120px;
    height: 19px;
    padding-top: 3px;
    text-decoration: none;
    color: #a5cae5;
    font-weight: 800;
    display: block;
  }

  #nav a:hover {
    color: #FFFFFF;
    font-weight: 800;
  }
</style>
