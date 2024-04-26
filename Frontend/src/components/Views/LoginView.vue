<script setup>
    import { computed, ref } from 'vue'
    import { loginUser } from '@/api/request.js'
    import router from '@/router.js'
    import { RouterLink } from 'vue-router';

    const email = ref("");
    const password = ref("");

    const errors = ref({
        email: '',
        password: '',
    })  

    async function login () {
        try {
            await loginUser(email.value, password.value);
            router.push('/');
        
        } catch (exception) {
            console.log( exception);
            errors.value = exception.errors;
        }

        email.value = "";
        password.value = "";
    }

    const canSubmit = computed(() => {
        return email.value === "" || password.value === ""
    });
</script>

<template>
<div>
  <div class="form-group" style="margin-bottom: 10px;">
    <label for="exampleInputEmail1">Email address</label>
    <input type="email" v-model="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
    <small id="error-email" v-if="errors.email">
        {{ errors.email }}
    </small>
  </div>
  <div class="form-group" style="margin-bottom: 10px;">
    <label for="exampleInputPassword1">Password</label>
    <input type="password" v-model="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
    <small id="error-password" v-if="errors.password" >
        {{ errors.password }}
    </small>
  </div>
  
  <button :disabled="canSubmit" @click="login" class="btn btn-primary">Submit</button>
  <div></div>
</div>
</template>