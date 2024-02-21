<template>
    <header>
        <Navbar />
    </header>
    <div class="container-lg my-3">
        <router-view></router-view>
    </div>
</template>

<script>
import Navbar from "@/components/Navbar.vue";

export default {
    components: {
        Navbar
    }
}
</script>

<style lang="scss" scoped></style>