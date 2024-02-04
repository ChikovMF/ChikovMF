<template>
    <div class="col">
        <div class="card">
            <img src="https://proprikol.ru/wp-content/uploads/2020/08/krasivye-kartinki-kotikov-55.jpg" class="card-img-top"
                alt="Изображение проекта">

            <div class="card-body">
                <h5 class="card-title">{{ project.name }}</h5>
                <p class="card-text">{{ project.description }}</p>
                <div v-for="tag in project.tags">
                    <small>{{ tag }}</small>
                </div>
                <MyButton>Подробнее</MyButton>
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
    }
}
</script>

<style lang="scss" scoped></style>
