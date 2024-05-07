<script setup>
import { ref,computed } from 'vue';
import { registerUser } from '@/api/request.js'
import router from '@/router.js';

    const username = ref("");
    const password = ref("");
    const email = ref("");

    const errors = ref({
        username: '', 
        password: '', 
        email: '', 
    });

    async function register () {
        try {
            await registerUser(username.value, password.value, email.value);
            console.log("cocknball")
            router.push('/login');
        } catch (exception) {
            console.error('register error', exception);
            errors.value = exception.errors;
            console.log(errors.username, errors.password, errors.email);
        }

        username.value = "";
        password.value = "";
        email.value = "";
    }

    const canSubmit = computed(() => {
        return username.value === "" || password.value === "" || email.value === "";
    });
</script>


<template>

<div>
  <div class="mb-3">
    <h3>Register New Account</h3>
    <label for="exampleInputEmail1" class="form-label">Email address</label>
    <input type="email" v-model="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp">
    <label class="form-check-label" for="exampleCheck1">{{ errors.email }}</label>
    <div id="emailHelp" class="form-text">We'll never share your email with anyone else.</div>
    </div>

    <label for="exampleInputEmail1" class="form-label">Username</label>
    <input type="text" v-model="username" class="form-control" aria-describedby="emailHelp">
    <label class="form-check-label" for="exampleCheck1">{{ errors.username }}</label>

    <label for="inputPassword5" class="form-label">Password</label>
    <input type="password" v-model="password" id="inputPassword5" class="form-control" aria-describedby="passwordHelpBlock">
    <label class="form-check-label" for="exampleCheck1">{{ errors.password }}</label>
    <div id="passwordHelpBlock" class="form-text">
        Your password must be 8-20 characters long
    </div>
  </div>
  <button :disabled="canSubmit" @click="register" class="btn btn-primary mt-3">Submit</button>
  
</template>