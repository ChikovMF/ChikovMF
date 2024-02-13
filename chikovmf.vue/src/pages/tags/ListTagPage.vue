<template>
    <PageTitle>
        Список тэгов
        <template v-slot:buttons>
            <router-link class="btn btn-sm" to="/Tags/Create">Создать тэг</router-link>
        </template>
    </PageTitle>

    <ErrorAlert :message="error" v-if="error" />

    <ListTag v-if="!loading && listModel" :tags="listModel.tags" />

    <Spinner v-else-if="loading" />
</template>

<script>
import ListTag from "@/components/tags/ListTag.vue";

export default {
    components: {
        ListTag
    },
    data() {
        return {
            loading: false,
            listModel: null,
            error: null
        }
    },
    created() {
        this.fetchData();
    },
    methods: {
        fetchData() {
            this.loading = true;
            this.listModel = null;

            const url = "/api/Tags";
            const requestOptions = {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            };
            fetch(url, requestOptions)
                .then(async response => {
                    if (response.status === 200) {
                        this.listModel = await response.json();
                    }
                    else {
                        this.error = response.status + ": " + response.statusText;
                    }
                    this.loading = false;
                })
        }
    },
}
</script>

<style lang="scss" scoped></style>