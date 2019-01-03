import Vue from 'vue'
import App from './App.vue'
import VueResource from 'vue-resource';
import VueRouter from 'vue-router'
import { store }  from './store/store'
import { appSettings } from './Settings';
import Result from './views/SearchResult'
import Home from './views/Home'
import Actor from './views/actor'
import Movie from './views/movie'
import 'typeface-roboto/index.css'

Vue.use(VueRouter)
Vue.use(VueResource)
Vue.http.options.root = 'https://moveee-api.azurewebsites.net/api'

Vue.filter('fullUrl', (imgUrl) => {
  if (!imgUrl) return appSettings.imgMissing
  return appSettings.imgBaseUrl342 + imgUrl
})


const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    { path: '/', name: 'home', component: Home }, 
    { path: '/actor', name: 'actor', component: Actor}, 
    { path: '/movie/', name: 'movie', component: Movie}, 
    { path: '/result/', name: 'result', component: Result}, 
    { path: '*', redirect: '/'
    }
  ]
})

new Vue({
  store,
  router,
  render: h => h(App)
}).$mount('#app')