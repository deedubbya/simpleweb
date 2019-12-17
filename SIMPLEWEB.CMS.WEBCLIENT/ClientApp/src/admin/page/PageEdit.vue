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
                   v-model="page.Status"
                   value="ACTIVE">
            <label class="form-check-label" for="inlineRadio1">Active</label>
          </div>
          <div class="form-check form-check-inline">
            <input class="form-check-input"
                   type="radio"
                   name="inlineRadioOptions"
                   id="inlineRadio2"
                   v-model="page.Status"
                   value="INACTIVE">
            <label class="form-check-label" for="inlineRadio2">InActive</label>
          </div>
        </div>
      </div>
      <div class="form-group">
        <label for="inputHomePage">Home Page</label>
        <div>
          <div class="form-check form-check-inline">
            <input class="form-check-input"
                   type="radio"
                   name="inlineRadioOptions2"
                   id="inlineRadio3"
                   v-model="page.IsHomePage"
                   value="true">
            <label class="form-check-label" for="inlineRadio3">Yes</label>
          </div>
          <div class="form-check form-check-inline">
            <input class="form-check-input"
                   type="radio"
                   name="inlineRadioOptions2"
                   id="inlineRadio4"
                   v-model="page.IsHomePage"
                   value="false">
            <label class="form-check-label" for="inlineRadio4">No</label>
          </div>
        </div>
      </div>
      <div class="form-group">
        <label for="InputTitle">Title</label>
        <input type="text"
                class="form-control"
                id="InputTitle"
                v-model="page.HeaderTitle"
                placeholder="Enter page title">
      </div>
      <div class="form-group">
        <label for="inputVisibility">Visibility</label>
        <div>
          <div class="form-check form-check-inline">
            <input class="form-check-input"
                    type="radio"
                    name="inlineRadioOptions3"
                    id="inlineRadio5"
                    v-model="page.Visibility"
                    value="visible">
            <label class="form-check-label" for="inlineRadio5">Visible</label>
          </div>
          <div class="form-check form-check-inline">
            <input class="form-check-input"
                    type="radio"
                    name="inlineRadioOptions3"
                    id="inlineRadio6"
                    v-model="page.Visibility"
                    value="hidden">
            <label class="form-check-label" for="inlineRadio6">Hidden</label>
          </div>
        </div>
      </div>
      <div class="form-group">
        <label for="InputHtml">HTML Content</label>
        <quill-editor id="InputHtml"
                      v-model="page.HtmlContent"
                      ref="InputHtmlEditor"
                      :options="editorOption"
                      @blur="onEditorBlur($event)"
                      @focus="onEditorFocus($event)"
                      @ready="onEditorReady($event)">
        </quill-editor>
      </div>
      <!--HtmlContent-->
      <button type="submit"
              class="btn btn-primary"
              @click.prevent="submit">
        Submit
      </button>
    </form>
  </div>
</template>
<script>
  import { mapGetters } from 'vuex';
  import { mapActions } from 'vuex';
  import 'quill/dist/quill.core.css';
  import 'quill/dist/quill.snow.css';
  import 'quill/dist/quill.bubble.css';
  import { quillEditor } from 'vue-quill-editor';
  
  export default {
    name: 'PageEdit',
    data: function () {
      return {
        editorOption: {
          debug: 'info',
          placeholder: 'Begin creating page content...',
          theme: 'snow',
          modules: {
            toolbar: [
              ['bold', 'italic', 'underline', 'strike'],
              [{ 'list': 'ordered' }, { 'list': 'bullet' }],
              [{ 'header': [1, 2, 3, 4, 5, 6, false] }],
              [{ 'color': [] }, { 'background': [] }],
              [{ 'font': [] }],
              [{ 'align': [] }],
              ['link', 'image'],
              ['clean']
            ]
          }
        },
        confirmed: false
      }
    },
    computed: {
      ...mapGetters(['page']),
      editor() {
        return this.$refs.InputHtmlEditor.quill;
      }
    },
    methods: {
      ...mapActions(['setPage', 'updatePage']),
      onEditorBlur(quill) {
        console.log('editor blur!', quill);
      },
      onEditorFocus(quill) {
        console.log('editor focus!', quill);
      },
      onEditorReady(quill) {
        console.log('editor ready!', quill);
      },
      onEditorChange({ quill, html, text }) {
        console.log('editor change!', quill, html, text);
        this.page.HtmlContent = html;
      },
      submit() {
        this.updatePage(this.page)
          .then(response => {
            this.confirmed = true;
            this.$router.push({
              name: 'PageDetail',
              params: { id: this.page.ID }
            });
          }, error => { console.log(error); });
      }
    },
    components: {
      quillEditor
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
      this.setPage(this.$route.params.id);
    },
    mounted() {
      console.log('this is current quill instance object', this.editor);
    }
  }
</script>
<style scoped>
  .quill-editor {
    height: 500px;
    margin-bottom: 100px;
  }
</style>
