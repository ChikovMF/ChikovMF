<template>

    <ImageSlider :images="project.images" />

     <p>{{ project.content }}</p>
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