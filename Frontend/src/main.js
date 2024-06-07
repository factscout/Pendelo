import './assets/main.css'
import 'bootstrap/dist/css/bootstrap.min.css';
import router from "./router.js";
import { createApp } from 'vue';
import App from './App.vue';
import VueGoogleMaps from '@fawmi/vue-google-maps';

const app = createApp(App)

app.use(router)

app.mount('#app')


app.use(VueGoogleMaps, {
  load: {
    key: 'AIzaSyA--yqQRNzJBjCB2E-GLvmCX8XMLpguKJ8',
  },
}).mount('#app');