<template>
  <div>
    <b-button-group class="breadcrumb">
      <b-btn variant="link" @click="$emit('BeginEdit')">Edit</b-btn>
    </b-button-group>
    <hr />
    <dl class="row">
      <dt class="col-sm-3">Title:</dt>
      <dd class="col-sm-9" v-text="nav.Title"></dd>
      <dt class="col-sm-3">Link Type:</dt>
      <dd class="col-sm-9" v-text="nav.LinkType"></dd>
      <dt v-if="nav.LinkType == 'PAGE'" class="col-sm-3">Page:</dt>
      <dd v-if="nav.LinkType == 'PAGE'"
          class="col-sm-9"
          v-text="nav.Page == null ? '' : nav.Page.HeaderTitle"></dd>
      <dt v-if="nav.LinkType == 'EXTERNAL'" class="col-sm-3">External Link:</dt>
      <dd v-if="nav.LinkType == 'EXTERNAL'"
          class="col-sm-9"
          v-text="nav.ExternalLink == null ? '' : nav.ExternalLink"></dd>
    </dl>
  </div>
</template>
<script>
  export default {
    name: 'MenuNavDetail',
    props: ['nav']
  }
</script>
