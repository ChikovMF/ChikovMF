<template>
    <ProjectList v-if="!loading" :projects="listModel.projects" />
    <span v-else>Загрузка...</span>
</template>

<script>
import ProjectList from "@/components/Projects/ProjectList/ProjectList.vue";

export default {
    components: {
        ProjectList,
    },
    data() {
        return {
            loading: false,
            listModel: null
        }
    },
    created() {
        this.fetchData();
    },
    methods: {
        fetchData() {
            this.loading = true;
            this.listModel = null;

            fetch('/api/Projects')
                .then(r => r.json())
                .then(json => {
                    this.listModel = json;
                    this.loading = false;
                    return;
                });
        }
    },
}
</script>

<style></style>
