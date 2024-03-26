<template>
    <header>
        <AdminNavbar v-if="$store.getters.isAuth" />
        <Navbar v-else />
    </header>
    <div class="container-lg my-3">
        <router-view></router-view>
    </div>
</template>

<script>
import Navbar from "@/components/Navbar.vue";
import AdminNavbar from "@/components/AdminNavbar.vue";

export default {
    components: {
        Navbar, AdminNavbar
    },
    created() {
        this.$store.commit('login', this.$cookies.get('token'));
    }
}
</script>

<style lang="scss" scoped></style>