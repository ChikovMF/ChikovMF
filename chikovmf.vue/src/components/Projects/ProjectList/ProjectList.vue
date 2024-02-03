<template>
    <div class="container">
        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-4">
            <ProjectCard :project="project" v-for="project in projects" />
        </div>
    </div>
</template>

<script>
import ProjectCard from "./ProjectCard.vue";

export default {
    props: {
        projects: {
            type: Array,
            required: true,
        }
    },
    components: {
        ProjectCard
    },
}
</script>

<style lang="scss" scoped></style>
