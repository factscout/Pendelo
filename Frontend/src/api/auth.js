import { computed, ref } from 'vue'

export const STORAGE_KEY = 'twitter_session_token'

const token = ref(localStorage.getItem(STORAGE_KEY))
export function useAuth () {
  function setToken (newToken) {
    token.value = newToken
    localStorage.setItem(STORAGE_KEY, newToken)
  }

  function logout () {
    token.value = ''
    localStorage.removeItem(STORAGE_KEY)
  }

  const isLoggedIn = computed(() => !!token.value)

  return {
    token,
    isLoggedIn,
    setToken,
    logout,
  }
}