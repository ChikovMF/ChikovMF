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
        send: function (project, images) {
            this.submitSuccessful = false;
            this.error = null;

            const url = "/api/projects/" + this.$route.params.projectId;
            const requestOptions = {
                method: 'PUT',
                headers: { 
                    'Content-Type': 'application/json', 
                    'Authorization': 'Bearer ' + this.$store.state.token,
                },
                body: JSON.stringify(project)
            };
            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        if (images.card || images.slider.length > 0) {
                            response.json().then(json => {
                                this.uploadImages(images, json);
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
        uploadImages(images, projectId) {
            console.log(images)
            const formData = new FormData();
            formData.append('card', images.card);
            for (let i = 0; i < images.slider.length; i++) {
                formData.append('slider', images.slider.item(i));
                console.log(images.slider.item(i))
            }

            const url = "/api/Projects/UploadImages/" + projectId;
            const requestOptions = {
                method: 'POST',
                headers: {
                    'Authorization': 'Bearer ' + this.$store.state.token,
                },
                body: formData
            };
            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        this.submitSuccessful = true;
                        this.load();
                    }
                    else {
                        console.log(response);
                        this.error = "Проект изменен, но во время изменения изображений возникла ошибка. (" + response.status + ": " + response.statusText + ")";
                    }
                })
        },
        load() {
            this.loading = true;
            this.project = null;

            const url = '/api/Projects/Edit/' + this.$route.params.projectId;
            const requestOptions = {
                method: 'GET',
                headers: { 
                    'Content-Type': 'application/json', 
                    'Authorization': 'Bearer ' + this.$store.state.token,
                },
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