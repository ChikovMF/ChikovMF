<template>
    <div class="d-flex justify-content-between flex-wrap flex-md-nowrap align-items-center pt-3 pb-2 mb-3 border-bottom">
        <h1>
            <slot>Заголовок страницы</slot>
        </h1>
        <div class="btn-toolbar mb-2 mb-md-0">
            <slot name="buttons"></slot>
        </div>
    </div>
</template>

<script>
import Breadcrumb from "@/components/UI/Breadcrumb.vue";

export default {
    name: "PageTitle",
    components: {
        Breadcrumb
    },
}
</script>

<style lang="scss" scoped></style>