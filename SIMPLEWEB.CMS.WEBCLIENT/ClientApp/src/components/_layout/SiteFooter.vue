<template>
  <div id="footer" class="row">
    <ul class="col-xs-12 col-sm-12 col-md-12">
      <li><a href="http://www.freewebsitetemplates.com">home</a></li> |
      <li><a href="http://www.freewebsitetemplates.com">our tours</a></li> |
      <li><a href="http://www.freewebsitetemplates.com">Photo gallery</a></li> |
      <li><a href="http://www.freewebsitetemplates.com">community</a></li> |
      <li><a href="http://www.freewebsitetemplates.com">about us</a></li> |
      <li><a href="http://www.freewebsitetemplates.com">contact us</a></li>
    </ul>
    <span>copyright goes here and privacy goes here</span>
  </div>
</template>
<script>
  export default {
    name: "SiteFooter"
  }
</script>
<style scoped>
  #footer {
    text-align: center;
    color: #FFFFFF;
    margin: 10px 25px;
  }

    #footer ul {
      margin: 5px auto;
    }

    #footer li {
      display: inline;
      float: none;
      text-align: center;
    }

    #footer a {
      color: #FFFFFF;
      font-weight: 900;
      text-decoration: none;
    }

      #footer a:hover {
        text-decoration: underline;
      }

    #footer span {
      display: block;
      clear: both;
      color: #FFFFFF;
      margin: 10px auto;
    }
</style>
