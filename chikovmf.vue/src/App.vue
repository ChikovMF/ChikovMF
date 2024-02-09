<template>
    <header>
        <Navbar />
    </header>
    <div class="container-lg">
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