<template>
    <PageTitle>
        Список проектов
        <template v-slot:buttons>
            <router-link class="btn btn-sm btn-outline-success" to="/Projects/Create">Создать проект</router-link>
        </template>
    </PageTitle>

    <ErrorAlert :message="error" v-if="error" />

    <ListProject v-if="!loading && listModel" :projects="listModel.projects" />

    <Spinner v-else-if="loading" />
</template>

<script>
import ListProject from "@/components/projects/ListProject.vue";

export default {
    components: {
        ListProject,
    },
    data() {
        return {
            loading: false,
            listModel: null,
            error: null
        }
    },
    created() {
        this.fetchData();
    },
    methods: {
        fetchData() {
            this.loading = true;
            this.listModel = null;

            const url = '/api/Projects';
            const requestOptions = {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            };
            fetch(url, requestOptions)
                .then(async response => {
                    if (response.status === 200) {
                        this.listModel = await response.json();
                    }
                    else {
                        this.error = response.status + ": " + response.statusText;
                    }
                    this.loading = false;
                });
        }
    },
}
</script>

<style></style>
