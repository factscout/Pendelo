<script setup>
import Navigation from "./components/Navigation.vue"
import Icon from "./assets/logo.png"
</script>

<template>
  <div class="container">
    <div class="grid">
      <aside class="sidebar sidebar--left">
        <!-- Icon-->
        <img :src="Icon" alt="Logo" class="logo">
        <!-- Navigation -->
        <Navigation/>
      </aside>
      <main class="content">
        <RouterView/>
      </main>
    </div>
  </div>
</template>

<style>
*, *::before, *::after {
  box-sizing: border-box;
}

body {
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen-Sans, Ubuntu, Cantarell, "Helvetica Neue", sans-serif;
  background: #75A47F;
  color: #f8fafc;
  margin: 0;
  display: flex;
}
main {
  margin-left: 250px; /* Gleiche Breite wie die Sidebar */
}
.container {
  display: flex;
  width: 100%;
  max-width: 100%;
  min-height: 100vh;
  padding: 0;
  margin: 0 auto;
}
.sidebar--left .router-link, .sidebar--left a {
  display: block;
  width: 100%;  
  text-align: center; 
  margin-bottom: 10px; 
}
.sidebar--left button {
  width: 100%;    
  height: 100px;
  border-radius: 20px; 
}

.sidebar--left {
    width: 250px; /* Breite der Sidebar */
    position: fixed; /* Fixierte Position, bleibt beim Scrollen sichtbar */
    left: 0; /* Links ausrichten */
    top: 0; /* Oben ausrichten */
    height: 100vh; /* Vollständige Höhe des Viewports */
    overflow-y: auto; /* Ermöglicht das Scrollen innerhalb der Sidebar, falls nötig */
    background-color: #BACD92; /* Hintergrundfarbe */
    z-index: 1000; /* Stellt sicher, dass die Sidebar über anderen Inhalten liegt */
    flex-direction: column; /* Richtet Kinder-Elemente vertikal aus */
    align-items: center; /* Zentriert Kinder-Elemente horizontal */
    padding-top: 10px; /* Gibt der gesamten Sidebar einen Abstand nach oben */
    display: flex;
}
  .logo img {
    max-height: 100%; /* Begrenzt die Höhe innerhalb des Containers */
    max-width: 100%; /* Begrenzt die Breite innerhalb des Containers */
  }
  .logo{
    height: 160px;
    width: 200px;
    margin-bottom: 100px ;
    display: flex;
    justify-content: center; /* Zentriert das Bild horizontal */
    align-items: center; /* Zentriert das Bild vertikal */
    margin-top: 20px; /* Fügt einen Abstand von 20px oben hinzu */
  }


</style>