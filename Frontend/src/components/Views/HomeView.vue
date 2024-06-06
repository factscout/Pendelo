<template>
<div class="container">
    <div class="row">
        <div class="col-md-8">
            <h3>Kilometer eintragen</h3>
            <form>
                <div class="mb-3">
                    <label for="distance" class="form-label">Gefahrene Kilometer
                    <input type="number"  class="form-control" id="input-distance" placeholder="Kilometer">
                </label>
                </div>
                <div class="mb-3">
                    <label for="date" class="form-label">Datum</label>
                    <input type="date" class="form-control" id="date">
                </div>
                <div class="mb-3">
                    <label for="time" class="form-label">Uhrzeit</label>
                    <input type="time" class="form-control" id="time">
                </div>
                <button type="submit" class="btn btn-primary">Eintragen</button>
            </form>
        </div>
        <!-- Liste der gefahrenen Kilometer -->
        <div class="col-md-4 side-block text-end" id="sec-block">
            <h3>Gefahrene Kilometer</h3>
            <ul class="list-group">
                <li class="list-group-item">10 km - 10.04.2024 - 15:00 Uhr</li>
                <li class="list-group-item">5 km - 09.04.2024 - 10:30 Uhr</li>
                <!-- Weitere Einträge -->
            </ul>  
        </div>
    </div>
</div>
  <div>
    <GMapMap
      :center="center"
      :zoom="7"
      map-type-id="terrain"
      style="width: 100%; height: 400px"
  >
    <GMapCluster>
      <GMapMarker
          :key="index"
          v-for="(company, index) in companies"
          :position="{ lat: company.latitude, lng: company.longitude }"
          :clickable="true"
          :draggable="false"
          @click="showInfo(company.name)"
      />
    </GMapCluster>
  </GMapMap>
  </div>
</template>


<script>
export default {
  name: 'App',
  data() {
    return {
      center: { lat: 37.4220, lng: -122.0841 }, // Zentrum deiner Karte
      companies: [], // Leeres Array für die Unternehmen
    };
  },
  mounted() {
    this.fetchCompanies();
  },
  methods: {
    fetchCompanies() {
      fetch('URL_DEINER_FETCH_ANFRAGE')
        .then(response => response.json())
        .then(data => {
          this.companies = data; // Speichere die erhaltenen Unternehmen in deiner Vue.js-Datenstruktur
        })
        .catch(error => {
          console.error('Error fetching companies:', error);
        });
    },
    showInfo(companyName) {
      // Hier kannst du Logik hinzufügen, um Informationen über das angeklickte Unternehmen anzuzeigen
      console.log("Clicked on:", companyName);
    }
  }
}
</script>
<style>
  body {
    margin: 0;
  }
</style>