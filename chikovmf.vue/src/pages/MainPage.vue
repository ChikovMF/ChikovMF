<template>
    <PageTitle>
        Главная страница
    </PageTitle>

    <div>
        <h1>Главная страница!</h1>
        <router-link to="/Projects">Проекты</router-link>
    </div>

    <p>
        {{ $store.state.isAuth }}
    </p>
</template>

<script>
export default {
}
</script>

<style lang="scss" scoped></style>