<template>
    <PageTitle>
        Добавить проект
    </PageTitle>

    <ErrorAlert :message="error" v-if="error" />
    <SuccessAlert :message="successAlertMessage" v-if="submitSuccessful" />

    <FormProject :project="project" v-on:sumbitform="send" />
</template>

<script>
import FormProject from "@/components/projects/FormProject.vue";

export default {
    components: {
        FormProject
    },
    data() {
        return {
            error: null,
            submitSuccessful: false,
            successAlertMessage: "Проект успешно добавлен",
            project: {
                "name": "",
                "description": "",
                "content": "",
                "tags": [],
                "links": []
            }
        }
    },
    methods: {
        send: function (project, images) {
            this.submitSuccessful = false;
            this.error = null;

            const url = "/api/Projects";
            const requestOptions = {
                method: 'POST',
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
                            this.project = {
                                "name": "",
                                "description": "",
                                "content": "",
                                "tags": []
                            }
                        }
                    }
                    else {
                        console.log(response);
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
                        this.project = {
                            "name": "",
                            "description": "",
                            "content": "",
                            "tags": []
                        }
                    }
                    else {
                        console.log(response);
                        this.error = "Проект добавлен, но во время добавления изображений возникла ошибка. (" + response.status + ": " + response.statusText + ")";
                    }
                });
        }
    }
}
</script>

<style lang="scss" scoped></style>