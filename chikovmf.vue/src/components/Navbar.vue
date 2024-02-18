<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <div class="container-fluid">
            <router-link class="navbar-brand" to="/">ChikovMF{{ $store.state.isAuth ? ' Admin' : '' }}</router-link>
            <button class="navbar-toggler" type="button" @click="ToggleNavMenu">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="navbar-collapse" :class="navMenuCssClass" id="navbarText">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active">
                        <router-link class="nav-link" to="/Projects">Проекты</router-link>
                    </li>
                    <li v-if="$store.state.isAuth" class="nav-item">
                        <router-link class="nav-link" to="/Tags">Тэги</router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>

<script>
export default {
    data() {
        return {
            collapseNavMenu: false,
            navMenuCssClass: "collapse"
        }
    },
    methods: {
        ToggleNavMenu() {
            this.collapseNavMenu = !this.collapseNavMenu;
            if (this.collapseNavMenu) {
                this.navMenuCssClass = "";
            }
            else {
                this.navMenuCssClass = "collapse";
            }
        }
    },
    watch:{
        $route (){
            this.collapseNavMenu = false;
            this.navMenuCssClass = "collapse";
        }
    }
} 

</script>

<style lang="scss" scoped></style>