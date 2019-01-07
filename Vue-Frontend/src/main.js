import Vue from 'vue'
import App from './App.vue'
import VueResource from 'vue-resource';
import VueRouter from 'vue-router'
import { appConfig } from './div/Config';
import Result from './views/SearchResult'
import Home from './views/Home'
import Actor from './views/Actor'
import Movie from './views/Movie'
import NotFound from './components/NotFound'
import 'typeface-roboto/index.css'

Vue.use(VueRouter)
Vue.use(VueResource)
Vue.http.options.root = 'https://moveee-api.azurewebsites.net/api'

Vue.filter('getFullUrl', (imgUrl) => {
  if(imgUrl == null) return appConfig.imgMissing
  return appConfig.imgBaseUrl342 + imgUrl
})

Vue.filter('formatDate', (date) => {
    if(date == null) return 'Unknown'
    return new Date(date).toLocaleDateString('us-en', { year: 'numeric', month: 'long', day: 'numeric' })
})

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
    { path: '/search', name: 'result', component: Result }, 
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