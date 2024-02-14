<template>
    <div class="col-auto mt-4">
        <div class="card" style="width: 18rem;">
            <img v-if="project.image"
                :src="project.image.src" class="card-img-top"
                :alt="project.image.alt">

            <div class="card-body">

                <h5 class="card-title">{{ project.name }}</h5>

                <p class="card-text">{{ project.description }}</p>

                <div>
                    <span class="tag badge bg-secondary" v-for="tag in project.tags">{{ tag }}</span    >
                </div>

                <button class="btn btn-sm" @click="routeEditPage(project.projectId)">Подробнее</button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props: {
        project: {
            type: Object,
            required: true,
        }
    },
    methods: {
        routeEditPage(projectId) {
            this.$router.push("/Projects/" + projectId);
        }
    }
}
</script>

<style scoped>
    .tag {
        margin-right: 3px
    }
</style>
