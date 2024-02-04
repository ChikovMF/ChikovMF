<template>
    <ProjectForm></ProjectForm>
    <ProjectList v-if="!loading" :projects="listModel.projects" />
</template>

<script>
import ProjectList from "@/components/Projects/ProjectList/ProjectList.vue";
import ProjectForm from "@/components/Projects/ProjectManager/ProjectForm.vue";

export default {
    components: {
        ProjectList,
        ProjectForm
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

            fetch('api/Projects')
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
