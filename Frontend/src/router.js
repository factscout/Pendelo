import { createRouter, createWebHistory } from 'vue-router'
import HomeView from "../src/components/Views/HomeView.vue"
import LoginView from "../src/components/Views/LoginView.vue"
import RegisterView from "../src/components/Views/RegisterView.vue"

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/login',
      name: 'login',
      component: LoginView
      
    },
    {
        path: '/register',
        name: 'register',
        component: RegisterView
    }
  ]
})

export default router
