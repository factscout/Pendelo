<script setup>
import { ref, computed, onMounted } from 'vue';
import VueDatePicker from '@vuepic/vue-datepicker';
import { createRide } from '@/api/request.js'
import { useAuth } from '@/api/auth'

const { isLoggedIn, logout } = useAuth()

const km = ref("");
const datetime = ref("");
const errors = ref({
    km: '', 
    datetime: '', 
    });

async function Rides () {
        try {
            await createRide(km.value, datetime.value);  
        } catch (exception) {
            console.error('register error', exception);
            errors.value = exception.errors;
            console.log(errors.km, errors.datetime);
        }

        km.value = "";
        datetime.value = "";
}

const canSubmit = computed(() => {
        return km.value === "" || datetime.value === "" ;
    });

</script>


<template>
<div class="container">
    <div class="row">
        <div  class="col-md-8">
            <h3>Kilometer eintragen</h3>
            <div>
                <div class="mb-3">
                    <label for="distance" class="form-label">Gefahrene Kilometer
                    <input type="number" v-model="km" class="form-control" id="input-distance" placeholder="Kilometer">
                    {{ errors.km }}
                </label>
                </div>
                <div class="mb-3">
                    <label for="date" class="form-label">Datum</label>
                    <VueDatePicker v-model="datetime" />
                    {{ errors.datetime }}
                </div>
                <button :disabled="canSubmit" @click="Rides	" type="submit" class="btn btn-primary">Eintragen</button>
              </div>
        </div>
        
        <!-- Liste der gefahrenen Kilometer -->
        <div class="col-md-4 side-block text-end" id="sec-block">
            <h3>Gefahrene Kilometer</h3>
            <ul class="list-group">
              <li class="list-group-item" v-for="(entry, index) in entries" :key="index">{{ entry }}</li>
            </ul>  
        </div>
    </div>
</div>
</template>

<style>
  body {
    margin: 0;
  }
</style>