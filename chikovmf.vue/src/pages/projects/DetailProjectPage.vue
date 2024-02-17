<template>
    <PageTitle>
        Проект: {{ projectTitle }}
        <template v-slot:buttons>
            <button class="btn btn-sm" @click="routeEditPage">Редактировать</button>
            <button class="btn btn-sm" @click="deleteCommand">Удалить</button>
        </template>
    </PageTitle>

    <ErrorAlert :message="error" v-if="error" />

    <DetailProject :project="project" v-if="!loading && project" />

    <Spinner v-else-if="loading" />
</template>

<script>
import DetailProject from "@/components/projects/DetailProject.vue";

export default {
    components: {
        DetailProject
    },
    data() {
        return {
            loading: false,
            error: null,
            project: null,
            projectTitle: ""
        }
    },
    created() {
        this.load();
    },
    methods: {
        load() {
            this.loading = true;
            this.project = null;

            const url = '/api/Projects/' + this.$route.params.projectId;
            const requestOptions = {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            };
            fetch(url, requestOptions)
                .then(async response => {
                    if (response.status === 200) {
                        this.project = await response.json();
                        this.projectTitle = this.project.name;
                    }
                    else {
                        this.error = response.status + ": " + response.statusText;
                    }
                    this.loading = false;
                });
        },
        routeEditPage() {
            this.$router.push("/Projects/Edit/" + this.$route.params.projectId);
        },
        deleteCommand() {
            const url = "/api/Projects/" + this.$route.params.projectId;
            const requestOptions = {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
            };
            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        this.$router.push("/Projects");
                    }
                    else {
                        console.log(`Ошибка удаления проекта ({projectId})`);
                    }
                })
        }

    }
}
</script>

<style lang="scss" scoped></style>