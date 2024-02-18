import {createRouter, createWebHistory} from "vue-router";

import MainPage from '@/pages/MainPage.vue';
import CreateProjectPage from '@/pages/projects/CreateProjectPage.vue';
import EditProjectPage from '@/pages/projects/EditProjectPage.vue';
import DetailProjectPage from '@/pages/projects/DetailProjectPage.vue';
import ListProjectPage from '@/pages/projects/ListProjectPage.vue';
import ListTagPage from '@/pages/tags/ListTagPage.vue';
import CreateTagPage from '@/pages/tags/CreateTagPage.vue';
import EditTagPage from '@/pages/tags/EditTagPage.vue';
import LoginPage from '@/pages/LoginPage.vue';
import AccessDeniedPage from '@/pages/AccessDeniedPage.vue'
import NotFoundPage from '@/pages/NotFoundPage.vue'

const routes = [
    {
        path: '/',
        component: MainPage,
        meta: {
            requireAuth: false,
        }
    },
    {
        path: '/Projects/Create',
        component: CreateProjectPage,
        meta: {
            requireAuth: true,
        }
    },
    {
        path: '/Projects',
        component: ListProjectPage,
        meta: {
            requireAuth: false,
        }
    },
    {
        path: '/Projects/Edit/:projectId',
        component: EditProjectPage,
        meta: {
            requireAuth: true,
        }
    },
    {
        path: '/Projects/:projectId',
        component: DetailProjectPage,
        meta: {
            requireAuth: false,
        }
    },
    {
        path: '/Tags',
        component: ListTagPage,
        meta: {
            requireAuth: true,
        }
    },
    {
        path: '/Tags/Create',
        component: CreateTagPage,
        meta: {
            requireAuth: true,
        }
    },
    {
        path: '/Tags/Edit/:tagId',
        component: EditTagPage,
        meta: {
            requireAuth: true,
        }
    },
    {
        path: '/Login',
        component: LoginPage,
        meta: {
            requireAuth: false,
        }
    },
    {
        path: '/AccessDenied',
        component: AccessDeniedPage,
        meta: {
            requireAuth: false,
        }
    },
    {
        path: '/:pathMatch(.*)*',
        name: '404',
        component: NotFoundPage,
        meta: {
            requireAuth: false,
        }
    }
]

const router = createRouter({
    routes,
    history: createWebHistory()
})

export default router;
