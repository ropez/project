import Vue from "vue";
import Router from "vue-router";
import Grid from "./components/Grid";
import BasePage from "./views/BasePage";

Vue.use(Router);
// trenger '' as home, /actor as actor og /movie as movie.
// Videre vil jeg kanskje ha ett indeks for hver side jeg blar i 
// søkerresultatene. E.g /search/1-2-3 etc.
// Husk wildcard for å begrense hvor bruker kan gå

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
    routes: [
      {
        path: '/',
        name: 'home',
        component: BasePage
      },
      {
        path: '/start',
        name: 'start',
        component: Grid
      }
    
    
  ]
});
