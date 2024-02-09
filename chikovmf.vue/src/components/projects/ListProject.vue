<template>
    <div class="row justify-content-center">
        <CardProject :project="project" v-for="project in projects" :key="project.projectId" />
    </div>
</template>

<script>
import CardProject from "@/components/projects/CardProject.vue";

export default {
    props: {
        projects: {
            type: Array,
            required: true,
        }
    },
    components: {
        CardProject
    },
}
</script>

<style lang="scss" scoped></style>
