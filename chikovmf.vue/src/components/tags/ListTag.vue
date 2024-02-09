<template>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">Название</th>
                <th scope="col">Команды</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="tag in tags" :key="tag.tagId">
                <td scope="row">{{ tag.name }}</td>
                <td>
                    <div class="btn-group d-flex justify-content-end" role="group" aria-label="Basic example">
                        <button type="button" class="btn btn-sm btn-outline-info" @click="routeEditPage(tag.tagId)">Редактировать</button>
                        <button type="button" class="btn btn-sm btn-outline-danger"
                            @click="deleteTag(tag.tagId)">Удалить</button>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
</template>

<script>
export default {
    props: {
        tags: {
            type: Array,
            required: true
        }
    },
    methods: {
        deleteTag(tagId) {
            const url = "/api/Tags/" + tagId;
            const requestOptions = {
                method: 'DELETE',
                headers: { 'Content-Type': 'application/json' },
            };
            fetch(url, requestOptions)
                .then(response => {
                    if (response.status === 200) {
                        const index = this.tags.findIndex((item) => { return (item.tagId === tagId) });
                        if (index > -1) {
                            this.tags.splice(index, 1);
                        }
                    }
                    else {
                        console.log(`Ошибка удаления тэга ({tagId})`);
                    }
                })
        },
        routeEditPage(tagId) {
            this.$router.push("/Tags/Edit/" + tagId);
        }
    }
}
</script>

<style lang="scss" scoped></style>