<template>
  <div id="header" class="row">
    <span>SIMPLEWEB</span>
  </div>
</template>
<script>
  export default {
    name: "SiteHeader"
  }
</script>
<style scoped>
  #header {
    position:relative;
    height: 220px;
    margin: 0px 25px;
    background-image: url(../../assets/images/gear-header.jpg);
    display: block;
    border-left: 3px solid #164871;
    border-right: 3px solid #164871;
    text-align:left;
  }
  #header span {
    position: absolute;
    bottom: 5px;
    left: 20px;
    font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
    font-size: 62px;
    color: #397EB7;
  }
</style>
