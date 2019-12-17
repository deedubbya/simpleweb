<template>
  <div class="container" style="margin-top:3px;">
    <template v-if="!inAdmin">
        <div id="main">
          <site-header></site-header>
          <site-nav></site-nav>
          <div id="content" class="row">
            <div id="left" class="col-xs-8 col-sm-8 col-md-8">
              <div class="post">
                <h1>Title goes here</h1><span>[05.11.2006]</span>
                <p>Don't forgot to check <a href="http://www.freewebsitetemplates.com">free website templates</a> every day, because we add at least one free website template daily.</p>

                <p>
                  This is a template designed by free website templates for you for free you can replace all the text by your own
                  text. This is just a place holder so you can see how the site would look like.
                </p>

                <p>
                  You can remove any link to our websites from this template you're  free to use the template without linking
                  back to us. Don't want your boss to know you used a free website template ;) .
                </p>

                <p>If you're having problems editing the template please don't hesitate to ask for help on the <a href="http://www.freewebsitetemplates.com/forum/">forum</a>.</p>

                <p>If you're looking for beautiful and professionally made templates you can find them at <a href="http://www.templatebeauty.com">Template Beauty</a>.</p>
                <p>To find great hosting providers visit <a href="http://www.webhostingzoom.com">Web Hosting Zoom</a>.</p>
              </div>
              <div class="post">
                <h1>Title goes here</h1><span>[04.11.2006]</span>
                <p>Don't forgot to check <a href="http://www.freewebsitetemplates.com">free website templates</a> every day, because we add at least one free website template daily.</p>

                <p>
                  This is a template designed by free website templates for you for free you can replace all the text by your own
                  text. This is just a place holder so you can see how the site would look like.
                </p>

                <p>
                  You can remove any link to our websites from this template you're  free to use the template without linking
                  back to us. Don't want your boss to know you used a free website template ;) .
                </p>

                <p>If you're having problems editing the template please don't hesitate to ask for help on the <a href="http://www.freewebsitetemplates.com/forum/">forum</a>.</p>

                <p>If you're looking for beautiful and professionally made templates you can find them at <a href="http://www.templatebeauty.com">Template Beauty</a>.</p>
                <p>To find great hosting providers visit <a href="http://www.webhostingzoom.com">Web Hosting Zoom</a>.</p>
              </div>
            </div>
            <div id="right" class="col-xs-4 col-sm-4 col-md-4">
              <p>Don't forgot to check <a href="http://www.freewebsitetemplates.com">free website templates</a> every day, because we add at least one free website template daily.</p>

              <p>
                This is a template designed by free website templates for you for free you can replace all the text by your own
                text. This is just a place holder so you can see how the site would look like.
              </p>

              <p>
                You can remove any link to our websites from this template you're  free to use the template without linking
                back to us. Don't want your boss to know you used a free website template ;) .
              </p>

              <p>If you're having problems editing the template please don't hesitate to ask for help on the <a href="http://www.freewebsitetemplates.com/forum/">forum</a>.</p>

              <p>If you're looking for beautiful and professionally made templates you can find them at <a href="http://www.templatebeauty.com">Template Beauty</a>.</p>
              <p>To find great hosting providers visit <a href="http://www.webhostingzoom.com">Web Hosting Zoom</a>.</p>
              <p>If you're looking for beautiful and professionally made templates you can find them at <a href="http://www.templatebeauty.com">Template Beauty</a>.</p>
              <p>To find great hosting providers visit <a href="http://www.webhostingzoom.com">Web Hosting Zoom</a>.</p>
              <p>If you're looking for beautiful and professionally made templates you can find them at <a href="http://www.templatebeauty.com">Template Beauty</a>.</p>
              <p>To find great hosting providers visit <a href="http://www.webhostingzoom.com">Web Hosting Zoom</a>.</p>
            </div>
            <router-view />
            <div class="clear"></div>
          </div>
        </div>
        <site-footer></site-footer>
    </template>
    <template v-else>
      <div class="page-header">SimpleWeb</div>
      <hr />
      <div class="row">
        <div class="col-xs-4 col-sm-4 col-md-3">
          <admin-nav></admin-nav>
        </div>
        <div class="col-xs-8 col-sm-8 col-md-9">
          <router-view />
        </div>
      </div>
    </template>
  </div>
</template>
<script>
  import SiteHeader from './components/_layout/SiteHeader';
  import MainSiteNav from './components/_layout/SiteNav';
  import MainSiteFooter from './components/_layout/SiteFooter';
  import AdminNav from './admin/shared/AdminNav';

  export default {
    name: 'App',
    data: function () {
      return {
        inAdmin: false
      }
    },
    watch: {
      $route: function () {
        if (this.$route.path.startsWith("/" + this.$store.state.adminDirectory)) {
          this.inAdmin = true;
        } else {
          this.inAdmin = false;
        }
      }
    },
    components: {
      'site-header': SiteHeader,
      'site-nav': MainSiteNav,
      'site-footer': MainSiteFooter,
      'admin-nav': AdminNav
    }
  }
</script>
<style>
  body {
    font-family: Verdana, Arial, Helvetica, sans-serif;
    font-size: 12px;
    margin: 0px;
    padding: 0px;
    background-color: #164871;
  }

  * {
    margin: 0px;
    padding: 0px;
  }

  .clear {
    clear: both;
  }

  #main {
    background: #397EB7; 
  }
  p, h1, a, span {
    font-family: Arial, Helvetica, sans-serif;
  }  
  #content {
    background-color: #a5cae5;
    margin: 0px 25px;
    padding: 0px 20px 0px 5px;
    border-left: 3px solid #164871;
    border-right: 3px solid #164871;
  }
  #left {
    margin: 20px 0px 30px 0px;
  }
  #left p {
    font-size: 12px;
    color: #000000;
    padding: 5px 0px;
  }
  #left a {
    color: #052d4e;
    font-weight: 800;
  }

  #left a:hover {
    color: #FFFFFF;
  }

  #left h1 {
    font-size: 16px;
    color: #052d4e;
    display: inline;
    font-weight: 900;
  }

  #left span {
    font-size: 12px;
    color: #007dda;
    font-weight: 900;
    display: inline;
    margin-left: 8px;
  }

  #right {
    background-color: #397eb7;
    color: #FFFFFF;
    font-weight: 900;
    padding: 10px 20px;
    margin: 30px 0px 20px 0px;
    display: inline;
  }

  #right p {
    padding: 7px 0px;
  }

  #right a {
    color: #FFFFFF;
    font-weight: 900;
  }

  #right a:hover {
    color: #052d4e;
  }

  .post {
    margin-top: 20px;
  }

  .post a {
  }

  .post a:hover {
  }

  .post p {
  }

  .admin-section {
    background-color: #a5cae5;
    padding: 20px;
    margin-bottom: 20px;
    border-radius: 10px;
  }

  .admin-content {
    background-color: #ffffff;
    padding: 20px;
    border-radius: 10px;
  }

  .page-header {
    color: #ffffff;
    font-size: 48px;
  }

</style>
