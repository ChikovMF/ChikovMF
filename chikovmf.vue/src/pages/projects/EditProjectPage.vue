<template>
    <PageTitle>
        Редактирование проекта: {{ $route.params.projectId }}
    </PageTitle>

    <ErrorAlert :message="error" v-if="error" />
    <SuccessAlert :message="successAlertMessage" v-if="submitSuccessful" />

    <FormProject v-if="!loading && project" :project="project" v-on:sumbitform="send" />
    
    <Spinner v-else-if="loading" />
</template>

<script>
import FormProject from "@/components/projects/FormProject.vue";

export default {
    components: {
        FormProject
    },
    data() {
        return {
            loading: false,
            error: null,
            submitSuccessful: false,
            successAlertMessage: "Проект успешно изменен",
            project: null
        }
    },
    created() {
        this.load();
    },
    methods: {
        send: function (project, cardImage) {
            this.submitSuccessful = false;
            this.error = null;

            const url = "/api/projects/" + this.$route.params.projectId;
            const requestOptions = {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(project)
            };
            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        if (cardImage) {
                            response.json().then(json => {
                                this.uploadCardImage(cardImage, json);
                            })

                        }
                        else {
                        this.submitSuccessful = true;
                        this.load();
                        }
                    }
                    else {
                        this.error = response.status + ": " + response.statusText;
                    }
                })
        },
        uploadCardImage(cardImage, projectId) {
            const formData = new FormData();
            formData.append('image', cardImage);

            const url = "/api/Projects/UploadCardImage/" + projectId;
            const requestOptions = {
                method: 'POST',
                body: formData
            };

            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        this.submitSuccessful = true;
                        this.load();
                    }
                    else {
                        this.error = "Проект изменен но во время обновления изображения карты возникла ошибка." + response.status + ": " + response.statusText;
                        this.load();
                    }
                })

        },
        load() {
            this.loading = true;
            this.project = null;

            const url = '/api/Projects/Edit/' + this.$route.params.projectId;
            const requestOptions = {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            };
            fetch(url, requestOptions)
                .then(async response => {
                    if (response.status === 200) {
                        this.project = await response.json();
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