import {createStore} from "vuex";

export default createStore({
    state: {
        bearToken: null,
        isAuth: false
    },
    getters: {
    },
    mutations: {
        setbBearToken(state, token) {
            state.bearToken = token;
            state.isAuth = true
        }
    },
    actions: {

    }
})