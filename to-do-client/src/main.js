import Vue from "vue";
import App from "./App.vue";
import Buefy from "buefy";
import moment from "moment";
import "buefy/dist/buefy.css";
import "@/plugins/axios";

Vue.use(Buefy);
Vue.config.productionTip = false;

Vue.filter("formatTimestamp", function (value) {
  return moment.utc(value).local().format("MMM Do, h:mma");
});

new Vue({
  render: (h) => h(App),
}).$mount("#app");
