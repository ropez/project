import Vue from 'vue';
import App from './App.vue';
import VueResource from 'vue-resource';
import VueRouter from 'vue-router';
import { appConfig } from './div/Config';
import Home from './views/Home';

//
// Lazy loading of some components
//

const Actor = resolve => {
  require.ensure(['./views/Actor'], () => {
      resolve(require('./views/Actor'));
  });
}

const Movie = resolve => {
  require.ensure(['./views/Movie'], () => {
      resolve(require('./views/Movie'));
  });
}

const SearchResult = resolve => {
  require.ensure(['./views/SearchResult'], () => {
      resolve(require('./views/SearchResult'));
  });
}

const NotFound = resolve => {
  require.ensure(['./components/NotFound'], () => {
      resolve(require('./components/NotFound'));
  });
}


Vue.use(VueRouter)
Vue.use(VueResource)
Vue.http.options.root = 'https://moveee-api.azurewebsites.net/api'


//
//  Filters
//


// The url stored in the database is just a part of the image url,
// and needs to be connected with the base url. 
// If the URL is null, we insert the url of a 'missing object' image.
Vue.filter('getFullUrl', (imgUrl) => {
  if(imgUrl == null) return appConfig.imgMissing
  return appConfig.imgBaseUrl342 + imgUrl
})

// Date is formatted to dd, mmmm, yyyy format
Vue.filter('formatDate', (date) => {
    if(date == null) return 'Unknown'
    return new Date(date).toLocaleDateString('us-en', { year: 'numeric', month: 'long', day: 'numeric' })
})

// Takes a JSON array and return a comma separated list/string
// Returns an empty string if the array is null.
Vue.filter('arrayToList', (array) => {
  let itemList = ''
  if(array  == null) return ''
  for(var i = 0; i < array.length; i++)
      itemList += array[i] + ', '
  return  itemList.slice(0, -2)
})

const router = new VueRouter({
  mode: 'history',
  routes: [
    { path: '/', name: 'home', component: Home }, 
    { path: '/actor/:id', name: 'actor', component: Actor }, 
    { path: '/movie/:id', name: 'movie', component: Movie }, 
    { path: '/search', name: 'result', component: SearchResult }, 
    { path: '*', name: 'notfound', component: NotFound 
    }
  ],
  scrollBehavior (to, from, savedPosition) {
    if (savedPosition) {
      return savedPosition
    } else {
      return { x: 0, y: 0 }
    }
  }
})

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')