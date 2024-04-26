import { useAuth } from './auth'
const backend = '/api'

const { token, setToken } = useAuth()

export async function registerUser (username, password, email){
    const response = await request(`/register`, {
        method: 'POST',
        body: JSON.stringify({ username, password, email }),
    })
}

export async function loginUser (email, password) {
    const response = await request(`/UserLogin`, {
        method: 'POST',
        body: JSON.stringify({ email, password }),
    })

    if (!response.token) {
        throw new Error('Login failed due to an unknown error')
    }

    setToken(response.token)

    return response.token
}


export async function checkAuth () {
    try {
        const response = await request(`/auth`, {
            method: 'GET',
        })

        if (response.token) {
            setToken(response.token)
        }

        return response
    } catch (error) {
        setToken('')
        return false
    }
}

async function request(url, options = {}) {
    const headers = {
        'Content-Type': 'application/json',
        'X-Requested-With': 'XMLHttpRequest',
    }

    if (token.value) {
        headers['Authorization'] = 'Bearer ' + token.value
    }

    const response = await fetch(backend + url, { headers, ...options })

    if (response.ok) {
        return response.json()
    } else if (response.status === 422) {
        const data = await response.json()

        throw new ValidationError('validation failed', data.errors)
    } else {
        throw new Error(`Server error: ${await response.text()}`)
    }
}
class ValidationError {
    message
    errors

    constructor (message, errors) {
        this.message = message
        this.errors = errors
    }
}