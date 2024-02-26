<template>
    <PageTitle>
        Доступ к запрошенному ресурсу запрещен (Access Denied 403)
    </PageTitle>

    <div class="container w-50 text-center">
        <img src="@/img/accessDenied.jpg" class="img-fluid" alt="Доступ запрещен">
        <br />
        <button class="btn" v-on:click="routeMain">На главную</button>
        <button class="btn" v-on:click="this.$router.push('/Login')">Войти</button>
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