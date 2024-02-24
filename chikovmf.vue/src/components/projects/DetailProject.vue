<template>
    <ImageSlider :images="project.images" />

    <div class="container mt-3">
        <div class="row">
            <div class="col-sm-12">
                <h2>О проекте:</h2>
                <p>{{ project.content }}</p>
            </div>
        </div>
    </div>

    <div class="container mt-3" v-if="project.tags">
        <div class="row">
            <div class="col-sm-12">
                <h2>Навыки используемые в проекте:</h2>
                <ul class="list-group list-group-horizontal-sm">
                    <li class="list-group-item" v-for="tag in project.tags"> {{ tag }} </li>
                </ul>
            </div>
        </div>
    </div>

    <div class="container mt-3" v-if="project.links && project.links.length > 0">
        <div class="row">
            <div class="col-sm-12">
                <h2>Ссылки на проект:</h2>
                <ul class="list-group">
                    <li class="list-group-item" v-for="link in project.links"><a :href="link.url"> {{ link.name }} </a></li>
                </ul>
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
        },
    },
}
</script>

<style lang="scss" scoped></style>