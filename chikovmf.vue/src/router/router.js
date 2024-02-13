import {createRouter, createWebHistory} from "vue-router";

import MainPage from '@/pages/MainPage.vue';
import CreateProjectPage from '@/pages/projects/CreateProjectPage.vue';
import EditProjectPage from '@/pages/projects/EditProjectPage.vue';
import ListProjectPage from '@/pages/projects/ListProjectPage.vue';
import ListTagPage from '@/pages/tags/ListTagPage.vue';
import CreateTagPage from '@/pages/tags/CreateTagPage.vue';
import EditTagPage from '@/pages/tags/EditTagPage.vue';

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
        component: ListProjectPage
    },
    {
        path: '/Projects/Edit/:projectId',
        component: EditProjectPage
    },
    {
        path: '/Tags',
        component: ListTagPage
    },
    {
        path: '/Tags/Create',
        component: CreateTagPage
    },
    {
        path: '/Tags/Edit/:tagId',
        component: EditTagPage
    },
]

const router = createRouter({
    routes,
    history: createWebHistory()
})

export default router;
