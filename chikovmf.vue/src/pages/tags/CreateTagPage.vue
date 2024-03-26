<template>
    <PageTitle>
        Добавить тэг
    </PageTitle>
    
    <ErrorAlert :message="error" v-if="error" />
    <SuccessAlert :message="successAlertMessage" v-if="submitSuccessful" />

    <FormTag :tag="tag" v-on:sumbitform="send" />
</template>

<script>
import FormTag from "@/components/tags/FormTag.vue";

export default {
    components: {
        FormTag
    },
    data() {
        return {
            error: null,
            submitSuccessful: false,
            successAlertMessage: "Тэг успешно создан",
            tag: {
                name: ""
            }
        }
    },
    methods: {
        send: function (tag) {
            console.log(tag);

            this.submitSuccessful = false;
            this.error = null;

            const url = "/api/Tags";
            const requestOptions = {
                method: 'POST',
                headers: { 
                    'Content-Type': 'application/json', 
                    'Authorization': 'Bearer ' + this.$store.state.token,
                },
                body: JSON.stringify(tag)
            };
            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        this.submitSuccessful = true;
                        tag.name = "";
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