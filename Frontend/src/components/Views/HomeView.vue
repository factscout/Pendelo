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



</template>

<style scoped>

</style>