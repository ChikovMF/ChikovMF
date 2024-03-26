import { createApp } from 'vue'
import VueCookies from 'vue3-cookies'
import App from './App.vue'
import components from '@/components/UI';
import router from '@/router/router';
import store from '@/store';

import 'bootstrap/dist/css/bootstrap.min.css';

const app = createApp(App);

components.forEach(component => {
    app.component(component.name, component);
});

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requireAuth) && !store.getters.isAuth) {
        next({
            path: '/AccessDenied',
        });
    } else {
        next();
    }
});

app.use(VueCookies, {
    expireTimes: "30d",
    path: "/",
    domain: "",
    secure: true,
    sameSite: "None"
});

app.use(router)
    .use(store)
    .mount('#app')
