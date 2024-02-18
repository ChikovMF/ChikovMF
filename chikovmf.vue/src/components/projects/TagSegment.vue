<template>
    <ErrorAlert :message="error" v-if="error" />

    <table class="table" v-if="!loading && selectTagsModel">
        <thead>
            <tr>
                <th scope="col">Положение</th>
                <th scope="col">Тэг</th>
                <th scope="col"></th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="tag in tags" :key="tag.tagId">
                <td>{{ tag.order }}</td>
                <td>
                    <select class="form-select" v-model="tag.tagId">
                        <option v-for="selectTag in selectTagsModel.tags" v-bind:value="selectTag.tagId"
                            :key="selectTag.tagId">
                            {{ selectTag.name }}
                        </option>
                    </select>
                </td>
                <td>
                    <button class="btn btn-sm btn-link" type="button" @click="deleteTag(tag.tagId)">
                        <svg width="1em" height="1em" viewBox="0 0 16 16" class="bi bi-x-circle-fill text-danger"
                            fill="currentColor" xmlns="http://www.w3.org/2000/svg">
                            <path fill-rule="evenodd"
                                d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM5.354 4.646a.5.5 0 1 0-.708.708L7.293 8l-2.647 2.646a.5.5 0 0 0 .708.708L8 8.707l2.646 2.647a.5.5 0 0 0 .708-.708L8.707 8l2.647-2.646a.5.5 0 0 0-.708-.708L8 7.293 5.354 4.646z" />
                        </svg>
                    </button>
                </td>
            </tr>
        </tbody>

        <div class="mt-1">
            <button class="btn btn-sm btn-outline-primary" type="button" @click="addTag">Добавить тэг</button>
        </div>

    </table>

    <Spinner v-else-if="loading" />
</template>

<script>
export default {
    data() {
        return {
            loading: false,
            selectTagsModel: null,
            error: null
        };
    },
    props: {
        tags: {
            type: Array,
            required: true,
        },
    },
    methods: {
        loadTagSelect() {
            this.loading = true;
            this.selectTags = null;
            const url = '/api/Tags';
            const requestOptions = {
                method: 'GET',
                headers: { 
                    'Content-Type': 'application/json', 
                    'Authorization': 'Bearer ' + this.$store.state.bearToken,
                },
            };
            fetch(url, requestOptions)
                .then(async (response) => {
                    if (response.status === 200) {
                        this.selectTagsModel = await response.json();
                    }
                    else {
                        this.error = response.status + ": " + response.statusText;
                    }
                    this.loading = false;
                });
        },
        addTag() {
            this.tags.push(
                {
                    order: this.tags.length + 1,
                    tagId: null
                });
        },
        deleteTag(tagId) {
            this.tags.splice(this.tags.indexOf(tag => tag.tagId == tagId), 1);
        }
    },
    created() {
        this.loadTagSelect();
    }
}
</script>

<style lang="scss" scoped></style>