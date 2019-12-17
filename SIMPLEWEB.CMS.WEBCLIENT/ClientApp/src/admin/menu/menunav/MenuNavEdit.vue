<template>
  <div>
    <div class="form-group">
      <label for="InputTitle">Title</label>
      <input type="text"
             class="form-control"
             id="InputTitle"
             v-model="nav.Title"
             placeholder="Enter navigation title">
    </div>
    <div class="form-group">
      <label for="inputLinkType">Link Type</label>
      <div>
        <div class="form-check form-check-inline">
          <input class="form-check-input"
                 type="radio"
                 :name="'inlineRadioOptions' + nav.ID"
                 :id="'inlineRadio' + nav.ID"
                 v-model="nav.LinkType"
                 value="PAGE"
                 @click="selectedLinkType = 'PAGE'">
          <label class="form-check-label" :for="'inlineRadio' + nav.ID">Page</label>
        </div>
        <div class="form-check form-check-inline">
          <input class="form-check-input"
                 type="radio"
                 :name="'inlineRadioOptions' + nav.ID"
                 :id="'inlineRadio' + nav.ID"
                 v-model="nav.LinkType"
                 value="EXTERNAL"
                 @click="selectedLinkType = 'EXTERNAL'">
          <label class="form-check-label" :for="'inlineRadio' + nav.ID">External Link</label>
        </div>
      </div>
    </div>
    <div class="form-group" v-if="selectedLinkType == 'PAGE'">
      <label for="InputPage">Page</label>
      <select class="form-control" id="InputPage" v-model="nav.PageID">
        <option v-for="page in pages" :value="page.ID">{{ page.HeaderTitle }}</option>
      </select>
    </div>
    <div class="form-group" v-if="selectedLinkType == 'EXTERNAL'">
      <label for="InputExternalLink">External Link</label>
      <input type="text"
             class="form-control"
             id="InputExternalLink"
             v-model="nav.ExternalLink"
             placeholder="Enter external link">
    </div>
    <div>
      <hr />
      <b-button-group class="breadcrumb">
        <b-btn variant="link" @click="$emit('HandleSave', nav)">Save</b-btn>
        <b-btn variant="link" @click="$emit('CancelEdit')">Cancel</b-btn>
      </b-button-group>
    </div>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';

  export default {
    name: 'MenuNavEdit',
    props: ['nav'],
    data: function () {
      return {
        selectedLinkType: ""
      }
    },
    computed: {
      ...mapGetters(['pages'])
    },
    methods: {
      ...mapActions(['setPages', 'updateMenuNavigationItem']),
     
    },
    created() {
      this.setPages();
      this.selectedLinkType = this.nav.LinkType;
      console.log(this.nav);
    }
  }
</script>
