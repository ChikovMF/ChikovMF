<template>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">Название</th>
                <th scope="col">Ссылка</th>
            </tr>
        </thead>

        <tbody>
            <tr v-for="link in links">
                <td>
                    <input type="text" v-model="link.name">
                </td>
                <td>
                    <input type="text" v-model="link.url">
                </td>
                <td>
                    <button class="btn btn-sm btn-link" type="button" @click="deleteLink(link)">
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
            <button class="btn btn-sm btn-outline-primary" type="button" @click="addLink">Добавить ссылку</button>
        </div>

    </table>
</template>

<script>
export default {
    props: {
        links: {
            type: Array,
            required: true,
        }
    },
    methods: {
        addLink() {
            this.links.push(
                {
                    name: "",
                    url: ""
                });
        },
        deleteLink(delLink) {
            this.links.splice(this.links.indexOf(link => link.name == delLink.name && link.url == delLink.url), 1);
        }
    }
}
</script>

<style lang="scss" scoped></style>