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
            successAlertMessage: "Тэг успешно создан",
            project: {
                "name": "",
                "description": "",
                "content": "",
                "tags": []
            }
        }
    },
    methods: {
        send: function (project) {
            console.log(project);

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
                        this.error = response.status + ": " + response.statusText;
                    }
                })
        }
    }
}
</script>

<style lang="scss" scoped></style>