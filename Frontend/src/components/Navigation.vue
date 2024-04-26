<script setup>
import { useAuth } from '../api/auth'

const { isLoggedIn, logout } = useAuth()

</script>


<template>
<aside>
    <nav class="nav" >
    <RouterLink to="/" exact id="buttons">
        <button type="button" class="btn btn-outline-dark rounded-pill">
            Dashboard
        </button>
    </RouterLink>   
    <div v-if="isLoggedIn == false" style="padding-left: 70px;"> 
        <RouterLink to="/register">
            <button type="button" class="btn btn-outline-dark">
                Register
            </button>
        </RouterLink>
        <RouterLink to="/login" >
            <button type="button" class="btn btn-outline-dark" >
                Login
            </button>
        </RouterLink >
    </div>
    <a v-else href="#" @click="logout" class="logout-link" id="buttons">
        <button type="button" class="btn btn-outline-danger btn-sm">
            Logout
        </button>
    </a>
  </nav>
</aside>

</template>
  
<style scoped>

.router-link {
  display: block; /* Lässt den RouterLink die gesamte verfügbare Breite einnehmen */
  padding: 5px 10px; /* Optional: Fügt etwas Abstand innerhalb der Links hinzu */
}
#buttons{
    background-color: transparent !important;
    color: black !important;    
}
.router-link-active {
    color: inherit;
    background-color: transparent;
}
.router-link-exact-active {
    color: inherit;
    background-color: transparent;
}
</style>
