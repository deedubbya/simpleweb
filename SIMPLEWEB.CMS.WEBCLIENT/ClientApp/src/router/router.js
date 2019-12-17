import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

//#region lazy loading main components
const Home = resolve => {
  require.ensure(['@/Home'], () => {
    resolve(require('@/Home'));
  }, 'home');
};
//#endregion

//#region lazy loading admin components
const BreadCrumb = resolve => {
  require.ensure(['@/admin/shared/BreadCrumb'], () => {
    resolve(require('@/admin/shared/BreadCrumb'));
  }, 'shared');
};

const AdminHome = resolve => {
  require.ensure(['@/admin/AdminHome'], () => {
    resolve(require('@/admin/AdminHome'));
  }, 'admin-home');
};

const Account = resolve => {
  require.ensure(['@/admin/account/Account'], () => {
    resolve(require('@/admin/account/Account'));
  }, 'account');
};

const User = resolve => {
  require.ensure(['@/admin/user/User'], () => {
    resolve(require('@/admin/user/User'));
  }, 'user');
};

const UserStart = resolve => {
  require.ensure(['@/admin/user/UserStart'], () => {
    resolve(require('@/admin/user/UserStart'));
  }, 'user');
};

const UserDetail = resolve => {
  require.ensure(['@/admin/user/UserDetail'], () => {
    resolve(require('@/admin/user/UserDetail'));
  }, 'user');
};

const UserEdit = resolve => {
  require.ensure(['@/admin/user/UserEdit'], () => {
    resolve(require('@/admin/user/UserEdit'));
  }, 'user');
};

const Menu = resolve => {
  require.ensure(['@/admin/menu/Menu'], () => {
    resolve(require('@/admin/menu/Menu'));
  }, 'menu');
};

const MenuStart = resolve => {
  require.ensure(['@/admin/menu/MenuStart'], () => {
    resolve(require('@/admin/menu/MenuStart'));
  }, 'menu');
};

const MenuDetail = resolve => {
  require.ensure(['@/admin/menu/MenuDetail'], () => {
    resolve(require('@/admin/menu/MenuDetail'));
  }, 'menu');
};

const MenuEdit = resolve => {
  require.ensure(['@/admin/menu/MenuEdit'], () => {
    resolve(require('@/admin/menu/MenuEdit'));
  }, 'menu');
};

const Page = resolve => {
  require.ensure(['@/admin/page/Page'], () => {
    resolve(require('@/admin/page/Page'));
  }, 'page');
};

const PageStart = resolve => {
  require.ensure(['@/admin/page/PageStart'], () => {
    resolve(require('@/admin/page/PageStart'));
  }, 'page');
};

const PageDetail = resolve => {
  require.ensure(['@/admin/page/PageDetail'], () => {
    resolve(require('@/admin/page/PageDetail'));
  }, 'page');
};

const PageEdit = resolve => {
  require.ensure(['@/admin/page/PageEdit'], () => {
    resolve(require('@/admin/page/PageEdit'));
  }, 'page');
};
//#endregion

export default new VueRouter({
  routes: [
    {
      path: '/home',
      name: 'Home',
      component: {
        default: Home
      }
    },
    {
      path: '/admin',
      name: 'Admin Home',
      components: {
        default: AdminHome
      }
    },
    {
      path: '/admin/account',
      name: 'Account',
      components: {
        default: Account
      }
    },
    {
      path: '/admin/user',
      name: 'User',
      components: {
        default: User
      },
      children: [
        {
          path: '/admin/user',
          name: 'UserStart',
          component: UserStart
        },
        {
          path: '/admin/user/detail/:id',
          name: 'UserDetail',
          component: UserDetail
        },
        {
          path: '/admin/user/edit/:id',
          name: 'UserEdit',
          component: UserEdit,
          beforeEnter: function (to, from, next) {
            let userAuthenticated = true;
            next(userAuthenticated);
          }
        }
      ]
    },
    {
      path: '/admin/menu',
      name: 'Menu',
      components: {
        default: Menu
      },
      children: [
        {
          path: '/admin/menu',
          name: 'MenuStart',
          component: MenuStart
        },
        {
          path: '/admin/menu/detail/:id',
          name: 'MenuDetail',
          component: MenuDetail
        },
        {
          path: '/admin/menu/edit/:id',
          name: 'MenuEdit',
          component: MenuEdit
        }
      ]
    },
    {
      path: '/admin/page',
      name: 'Page',
      components: {
        default: Page
      },
      children: [
        {
          path: '/admin/page',
          name: 'PageStart',
          component: PageStart
        },
        {
          path: '/admin/page/detail/:id',
          name: 'PageDetail',
          component: PageDetail
        },
        {
          path: '/admin/page/edit/:id',
          name: 'PageEdit',
          component: PageEdit
        }
      ]
    }
  ]
});
