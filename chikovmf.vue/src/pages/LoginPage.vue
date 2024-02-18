<template>
    <ErrorAlert :message="error" v-if="error" />
    <SuccessAlert :message="successAlertMessage" v-if="submitSuccessful" />

    <form v-if="!loading" @submit.prevent="send">
        <div class="input-group col-12">
            <label class="input-group-text" for="token">Токен</label>
            <input type="text" class="form-control" id="token" v-model="token" name="token" />
        </div>
    </form>

    <Spinner v-else-if="loading" />
</template>

<script>
export default {
    data() {
        return {
            token: null,
            loading: false,
            error: null,
            successAlertMessage: "Токен для входа отправлен.",
            submitSuccessful: false,
        }
    },
    created() {
        this.load();
    },
    methods: {
        send() {
            this.submitSuccessful = false;
            this.error = null;

            const url = "/api/Auth?token=" + this.token;
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
            };
            
            fetch(url, requestOptions)
                .then(async response => {
                    if (response.status === 200) {
                        let token = await response.text();
                        this.$store.commit('setbBearToken', token);
                        this.token = "";
                    }
                    else {
                        console.log(response);
                        this.error = response.status + ": " + response.statusText;
                    }
                })
        },
        load() {
            this.loading = true;

            const url = '/api/Auth';
            const requestOptions = {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            };
            fetch(url, requestOptions)
                .then(async response => {
                    if (response.status === 200) {
                        this.submitSuccessful = true;
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