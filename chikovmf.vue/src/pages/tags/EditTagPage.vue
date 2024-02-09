<template>
    <PageTitle>
        Редактирование тэга: {{ $route.params.tagId }}
    </PageTitle>

    <ErrorAlert :message="error" v-if="error" />
    <SuccessAlert :message="successAlertMessage" v-if="submitSuccessful" />

    <FormTag v-if="!loading && tag" :tag="tag" v-on:sumbitform="send" />
    
    <Spinner v-else-if="loading" />
</template>

<script>
import FormTag from "@/components/tags/FormTag.vue";

export default {
    components: {
        FormTag
    },
    data() {
        return {
            loading: false,
            error: null,
            submitSuccessful: false,
            successAlertMessage: "Тэг успешно изменен",
            tag: null
        }
    },
    created() {
        this.load();
    },
    methods: {
        send: function (tag) {
            this.submitSuccessful = false;
            this.error = null;

            const url = "/api/tags/" + this.$route.params.tagId;
            const requestOptions = {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(tag)
            };
            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        this.submitSuccessful = true;
                        this.load();
                    }
                    else {
                        this.error = response.status + ": " + response.statusText;
                    }
                })
        },
        load() {
            this.loading = true;
            this.tag = null;

            const url = '/api/Tags/Edit/' + this.$route.params.tagId;
            const requestOptions = {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            };
            fetch(url, requestOptions)
                .then(async response => {
                    if (response.status === 200) {
                        this.tag = await response.json();
                    }
                    else {
                        this.error = response.status + ": " + response.statusText;
                    }
                    this.loading = false;
                });
        }
    }
}
</script>

<style lang="scss" scoped></style>