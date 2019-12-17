webpackJsonp([3],{C23L:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var a={name:"Menu",data:function(){return{links:[]}},watch:{$route:function(e,t){this.buildLinkList(),e&&("MenuDetail"!=e.name&&"MenuEdit"!=e.name||this.links.push({name:"Menu Detail",href:"/menu/detail/"+this.$route.params.id}),"MenuEdit"==e.name&&this.links.push({name:"Menu Edit",href:"/menu/edit/"+this.$route.params.id}))}},methods:{buildLinkList:function(){this.links=[{name:"Menu",href:"/menu"}]}},components:{"app-breadcrumb":n("gRN6").default},created:function(){this.buildLinkList()}},i={render:function(){var e=this.$createElement,t=this._self._c||e;return t("div",{staticClass:"admin-section"},[t("h2",[this._v("Menus")]),this._v(" "),t("app-breadcrumb",{attrs:{links:this.links}}),this._v(" "),t("router-view")],1)},staticRenderFns:[]},s=n("VU/8")(a,i,!1,null,null,null);t.default=s.exports},avmv:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var a=n("Dd8w"),i=n.n(a),s=n("NYxO"),r={render:function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",[n("b-button-group",{staticClass:"breadcrumb"},[n("b-btn",{attrs:{variant:"link"},on:{click:function(t){e.$emit("BeginEdit")}}},[e._v("Edit")])],1),e._v(" "),n("hr"),e._v(" "),n("dl",{staticClass:"row"},[n("dt",{staticClass:"col-sm-3"},[e._v("Title:")]),e._v(" "),n("dd",{staticClass:"col-sm-9",domProps:{textContent:e._s(e.nav.Title)}}),e._v(" "),n("dt",{staticClass:"col-sm-3"},[e._v("Link Type:")]),e._v(" "),n("dd",{staticClass:"col-sm-9",domProps:{textContent:e._s(e.nav.LinkType)}}),e._v(" "),"PAGE"==e.nav.LinkType?n("dt",{staticClass:"col-sm-3"},[e._v("Page:")]):e._e(),e._v(" "),"PAGE"==e.nav.LinkType?n("dd",{staticClass:"col-sm-9",domProps:{textContent:e._s(null==e.nav.Page?"":e.nav.Page.HeaderTitle)}}):e._e(),e._v(" "),"EXTERNAL"==e.nav.LinkType?n("dt",{staticClass:"col-sm-3"},[e._v("External Link:")]):e._e(),e._v(" "),"EXTERNAL"==e.nav.LinkType?n("dd",{staticClass:"col-sm-9",domProps:{textContent:e._s(null==e.nav.ExternalLink?"":e.nav.ExternalLink)}}):e._e()])],1)},staticRenderFns:[]},l=n("VU/8")({name:"MenuNavDetail",props:["nav"]},r,!1,null,null,null).exports,o={name:"MenuNavEdit",props:["nav"],data:function(){return{selectedLinkType:""}},computed:i()({},Object(s.c)(["pages"])),methods:i()({},Object(s.b)(["setPages","updateMenuNavigationItem"])),created:function(){this.setPages(),this.selectedLinkType=this.nav.LinkType,console.log(this.nav)}},c={render:function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",[n("div",{staticClass:"form-group"},[n("label",{attrs:{for:"InputTitle"}},[e._v("Title")]),e._v(" "),n("input",{directives:[{name:"model",rawName:"v-model",value:e.nav.Title,expression:"nav.Title"}],staticClass:"form-control",attrs:{type:"text",id:"InputTitle",placeholder:"Enter navigation title"},domProps:{value:e.nav.Title},on:{input:function(t){t.target.composing||e.$set(e.nav,"Title",t.target.value)}}})]),e._v(" "),n("div",{staticClass:"form-group"},[n("label",{attrs:{for:"inputLinkType"}},[e._v("Link Type")]),e._v(" "),n("div",[n("div",{staticClass:"form-check form-check-inline"},[n("input",{directives:[{name:"model",rawName:"v-model",value:e.nav.LinkType,expression:"nav.LinkType"}],staticClass:"form-check-input",attrs:{type:"radio",name:"inlineRadioOptions"+e.nav.ID,id:"inlineRadio"+e.nav.ID,value:"PAGE"},domProps:{checked:e._q(e.nav.LinkType,"PAGE")},on:{click:function(t){e.selectedLinkType="PAGE"},change:function(t){e.$set(e.nav,"LinkType","PAGE")}}}),e._v(" "),n("label",{staticClass:"form-check-label",attrs:{for:"inlineRadio"+e.nav.ID}},[e._v("Page")])]),e._v(" "),n("div",{staticClass:"form-check form-check-inline"},[n("input",{directives:[{name:"model",rawName:"v-model",value:e.nav.LinkType,expression:"nav.LinkType"}],staticClass:"form-check-input",attrs:{type:"radio",name:"inlineRadioOptions"+e.nav.ID,id:"inlineRadio"+e.nav.ID,value:"EXTERNAL"},domProps:{checked:e._q(e.nav.LinkType,"EXTERNAL")},on:{click:function(t){e.selectedLinkType="EXTERNAL"},change:function(t){e.$set(e.nav,"LinkType","EXTERNAL")}}}),e._v(" "),n("label",{staticClass:"form-check-label",attrs:{for:"inlineRadio"+e.nav.ID}},[e._v("External Link")])])])]),e._v(" "),"PAGE"==e.selectedLinkType?n("div",{staticClass:"form-group"},[n("label",{attrs:{for:"InputPage"}},[e._v("Page")]),e._v(" "),n("select",{directives:[{name:"model",rawName:"v-model",value:e.nav.PageID,expression:"nav.PageID"}],staticClass:"form-control",attrs:{id:"InputPage"},on:{change:function(t){var n=Array.prototype.filter.call(t.target.options,function(e){return e.selected}).map(function(e){return"_value"in e?e._value:e.value});e.$set(e.nav,"PageID",t.target.multiple?n:n[0])}}},e._l(e.pages,function(t){return n("option",{domProps:{value:t.ID}},[e._v(e._s(t.HeaderTitle))])}),0)]):e._e(),e._v(" "),"EXTERNAL"==e.selectedLinkType?n("div",{staticClass:"form-group"},[n("label",{attrs:{for:"InputExternalLink"}},[e._v("External Link")]),e._v(" "),n("input",{directives:[{name:"model",rawName:"v-model",value:e.nav.ExternalLink,expression:"nav.ExternalLink"}],staticClass:"form-control",attrs:{type:"text",id:"InputExternalLink",placeholder:"Enter external link"},domProps:{value:e.nav.ExternalLink},on:{input:function(t){t.target.composing||e.$set(e.nav,"ExternalLink",t.target.value)}}})]):e._e(),e._v(" "),n("div",[n("hr"),e._v(" "),n("b-button-group",{staticClass:"breadcrumb"},[n("b-btn",{attrs:{variant:"link"},on:{click:function(t){e.$emit("HandleSave",e.nav)}}},[e._v("Save")]),e._v(" "),n("b-btn",{attrs:{variant:"link"},on:{click:function(t){e.$emit("CancelEdit")}}},[e._v("Cancel")])],1)],1)])},staticRenderFns:[]},u=n("VU/8")(o,c,!1,null,null,null).exports,d={name:"MenuEdit",data:function(){return{confirmed:!1,editing:!1}},computed:i()({},Object(s.c)(["menu"])),methods:i()({},Object(s.b)(["setMenu","updateMenu","updateMenuNavigationItem"]),{saveNavItem:function(e){var t=this;this.updateMenuNavigationItem(e).then(function(e){t.setMenu(t.$route.params.id),t.editing=!1},function(e){console.log(e)})},submit:function(){var e=this;this.updateMenu(this.menu).then(function(t){e.confirmed=!0,e.$router.push({name:"MenuDetail",params:{id:e.menu.ID}})},function(e){console.log(e)})}}),components:{"menu-nav-detail":l,"menu-nav-edit":u},beforeRouteLeave:function(e,t,n){this.confirmed?n():n(confirm("Are you sure?"))},created:function(){this.setMenu(this.$route.params.id)}},v={render:function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"admin-content"},[n("form",[n("div",{staticClass:"form-group"},[n("label",{attrs:{for:"InputName"}},[e._v("Name")]),e._v(" "),n("input",{directives:[{name:"model",rawName:"v-model",value:e.menu.Name,expression:"menu.Name"}],staticClass:"form-control",attrs:{type:"text",id:"InputName",placeholder:"Enter menu name"},domProps:{value:e.menu.Name},on:{input:function(t){t.target.composing||e.$set(e.menu,"Name",t.target.value)}}})]),e._v(" "),n("div",{staticClass:"form-group"},[n("label",{attrs:{for:"InputNavItems"}},[e._v("Navigation Items")]),e._v(" "),n("div",{attrs:{id:"InputNavItems"}},[n("div",{attrs:{role:"tablist"}},e._l(e.menu.NavigationItems,function(t){return n("b-card",{staticClass:"mb-1",attrs:{"no-body":""}},[n("b-card-header",{staticClass:"p-1",attrs:{"header-tag":"header",role:"tab"},on:{click:function(t){e.editing=!1}}},[n("b-btn",{directives:[{name:"b-toggle",rawName:"v-b-toggle",value:"accordion"+t.ID,expression:"'accordion' + nav.ID"}],staticClass:"text-left",attrs:{block:"",href:"#",variant:"info"},domProps:{textContent:e._s(t.Title)}})],1),e._v(" "),n("b-collapse",{attrs:{id:"accordion"+t.ID,accordion:"navAccordion",role:"tabpanel"}},[n("b-card-body",[e.editing?e._e():n("menu-nav-detail",{attrs:{nav:t},on:{BeginEdit:function(t){e.editing=!0}}}),e._v(" "),e.editing?n("menu-nav-edit",{attrs:{nav:t},on:{CancelEdit:function(t){e.editing=!1},HandleSave:e.saveNavItem}}):e._e()],1)],1)],1)}),1)])]),e._v(" "),n("button",{staticClass:"btn btn-primary",attrs:{type:"submit"},on:{click:function(t){return t.preventDefault(),e.submit(t)}}},[e._v("\n      Submit\n    ")])])])},staticRenderFns:[]},m=n("VU/8")(d,v,!1,null,null,null);t.default=m.exports},j76W:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var a=n("Dd8w"),i=n.n(a),s=n("NYxO"),r={name:"MenuStart",computed:i()({},Object(s.c)(["menus","activeMenus","inactiveMenus"])),methods:i()({},Object(s.b)(["setMenus"])),created:function(){this.setMenus()}},l={render:function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"admin-content"},[n("p",[e._v("Please select a Menu")]),e._v(" "),n("ul",{staticClass:"list-group"},e._l(e.menus,function(t){return n("router-link",{staticClass:"list-group-item",staticStyle:{cursor:"pointer"},attrs:{tag:"li",to:{name:"MenuDetail",params:{id:t.ID}}}},[e._v("\n      "+e._s(t.Name)+"\n    ")])}),1)])},staticRenderFns:[]},o=n("VU/8")(r,l,!1,null,null,null);t.default=o.exports},"yE/j":function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var a=n("Dd8w"),i=n.n(a),s=n("NYxO"),r={name:"MenuDetail",computed:i()({},Object(s.c)(["menu"])),methods:i()({},Object(s.b)(["setMenu"])),created:function(){this.setMenu(this.$route.params.id)}},l={render:function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{staticClass:"admin-content"},[n("dl",{staticClass:"row"},[n("dt",{staticClass:"col-sm-3"},[e._v("ID:")]),e._v(" "),n("dd",{staticClass:"col-sm-9"},[e._v(e._s(e.menu.ID))]),e._v(" "),n("dt",{staticClass:"col-sm-3"},[e._v("Name:")]),e._v(" "),n("dd",{staticClass:"col-sm-9"},[e._v(e._s(e.menu.Name))])]),e._v(" "),n("router-link",{staticClass:"btn btn-primary",attrs:{to:{name:"MenuEdit",params:{id:e.$route.params.id}}}},[e._v("Edit Menu")])],1)},staticRenderFns:[]},o=n("VU/8")(r,l,!1,null,null,null);t.default=o.exports}});
//# sourceMappingURL=3.b3b74b31d72aabe85003.js.map