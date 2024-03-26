import { createStore } from "vuex";

export default createStore({
    state: {
        token: null,
    },
    getters: {
        isAuth(state) {
            return state.token ? true : false;
        }
    },
    mutations: {
        login(state, token) {
            state.token = token;
        },
        relogin(state) {
            state.token = null;
        }
    },
    actions: { }
})