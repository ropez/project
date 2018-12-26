import Vue from "vue";
import App from "./App.vue";
import VueResource from 'vue-resource';
import router from "./router";

// Husk at de som står øverst blir loada med en gang ^^
// Husk lazy components
//Hente ruter sider fra..
Vue.config.productionTip = false;
Vue.use(VueResource);
Vue.http.options.root = 'https://moveee-api.azurewebsites.net/api/';
export const eventBus = new Vue();

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
