<template>
    <div class="col-auto mt-4">
        <div class="card" style="width: 18rem;">
            <img src="https://proprikol.ru/wp-content/uploads/2020/08/krasivye-kartinki-kotikov-55.jpg" class="card-img-top"
                alt="Изображение проекта {{ project.name }}">

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
