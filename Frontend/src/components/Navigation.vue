<script setup>

</script>

<template>
<aside>
    <nav class="nav" >
    <RouterLink to="/" exact id="buttons">
        <button type="button" class="btn btn-outline-dark rounded-pill">
            Dashboard
        </button>
    </RouterLink>
    <RouterLink to="/login" id="buttons" v-if="isLoggedIn == false">
        <button type="button" class="btn btn-outline-dark rounded-pill">
            Login
        </button>
    </RouterLink>
    <a href="#" @click="logout" class="logout-link" v-if="isLoggedIn == true">
        <button type="button" class="btn btn-outline-dark">
            Logout
        </button>
    </a>
    <RouterLink to="/register" id="buttons">
        <button type="button" class="btn btn-outline-dark rounded-pill">
            Register
        </button>
    </RouterLink>
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
