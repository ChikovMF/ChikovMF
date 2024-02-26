<template>
    <PageTitle>
        Страница не найдена (Not Found 404)
    </PageTitle>

    <div class="container w-50 text-center">
        <img src="@/img/notFound.jpg" class="img-fluid" alt="Страница не найдена">
        <br />
        <button class="btn" v-on:click="routeMain">На главную</button>
    </div>
</template>

<script>
    export default {
        methods: {
            routeMain() {
                this.$router.push("/");
            }
        }
    }
</script>

<style lang="scss" scoped>

</style>