import { createApp } from 'vue'
import App from './App.vue'
import components from '@/components/UI';
import router from '@/router/router';
import store from '@/store'

const app = createApp(App);

components.forEach(component => {
    app.component(component.name, component);
});

router.beforeEach((to, from, next) => {
    if (to.matched.some(record => record.meta.requireAuth) && !store.state.isAuth) {
        next({
            path: '/AccessDenied',
        });
    } else {
        next();
    }
});

app.use(router)
    .use(store)
    .mount('#app')
