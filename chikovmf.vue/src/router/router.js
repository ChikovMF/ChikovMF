import {createRouter, createWebHistory} from "vue-router";

import MainPage from '@/pages/MainPage.vue';
import CreateProjectPage from '@/pages/CreateProjectPage.vue';
import ProjectListPage from '@/pages/ProjectListPage.vue';

const routes = [
    {
        path: '/',
        component: MainPage
    },
    {
        path: '/Projects/Create',
        component: CreateProjectPage
    },
    {
        path: '/Projects',
        component: ProjectListPage
    },
]

const router = createRouter({
    routes,
    history: createWebHistory()
})

export default router;
