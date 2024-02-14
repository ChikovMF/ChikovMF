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
                "tags": []
            }
        }
    },
    methods: {
        send: function (project, cardImage) {
            this.submitSuccessful = false;
            this.error = null;

            const url = "/api/Projects";
            const requestOptions = {
                method: 'POST',
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
                        this.project = {
                            "name": "",
                            "description": "",
                            "content": "",
                            "tags": []
                        }
                    }
                    else {
                        console.log(response);
                        this.error = "Проект добавлен но во время добавления изображения карты возникла ошибка." + response.status + ": " + response.statusText;
                    }
                })

        }
    }
}
</script>

<style lang="scss" scoped></style>