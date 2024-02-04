<template>
    <div>
        <label>Название</label>
        <MyInput v-model="project.name"></MyInput>
        <br />

        <label>Описание</label>
        <MyAreaImput v-model="project.description"></MyAreaImput>

        <label>Описание</label>
        <MyAreaImput v-model="project.content"></MyAreaImput>

        <MyButton @click="send">Отправить</MyButton>
    </div>
</template>

<script>
export default {
    data() {
        return {
            project: {
                "name": '',
                "description": '',
                "content": '',
                "tags": []
            },
            projectId: null
        }
    },
    methods: {
        async send() {
            console.log(this.project)
            const url = "api/projects";
            const signal = JSON.stringify();
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(this.project)
            };
            fetch(url, requestOptions)
                .then(response => response.json())
                .then(data => {
                    this.projectId = data;

                    this.project = {
                        "name": '',
                        "description": '',
                        "content": '',
                        "tags": []
                    }
                });
        }
    }
}
</script>

<style lang="scss" scoped></style>
