export const dev = window.location.origin.includes('localhost')
export const baseURL = dev ? 'https://localhost:5001' : '' // TODO don't forget to change me!!!
export const domain = 'demodays.us.auth0.com'
export const audience = 'https://student-auth.com'
export const clientId = 'sPPms5w1gGrBv5T6hY9vj1xZWwT7HoCj'

export const useSockets = false
