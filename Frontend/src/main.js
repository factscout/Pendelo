import './assets/main.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import router from "./router.js";
import { createApp } from 'vue';
import App from './App.vue';
import '@vuepic/vue-datepicker/dist/main.css';

const app = createApp(App)

app.use(router)

app.mount('#app')

