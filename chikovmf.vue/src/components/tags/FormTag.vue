<template>
    <form class="row row-cols-lg-auto g-3 align-items-center" id="tagForm" @submit.prevent="sumbitform">

        <div class="input-group col-12">
            <label class="input-group-text" for="name">Название</label>
            <input class="form-control" type="text" id="name" v-model="tag.name" name="name" />
        </div>

        <div v-if="errors.length">
            <b>Возникли следующие ошибки:</b>
            <ul>
                <li v-for="error in errors">{{ error }}</li>
            </ul>
        </div>

        <div class="col-12">
            <input class="btn btn-sm btn-outline-success" type="submit" value="Отправить" />
        </div>

    </form>
</template>

<script>
export default {
    data() {
        return {
            errors: [],
        }
    },
    props: {
        tag: {
            type: Object,
            required: true,
        }
    },
    methods: {
        sumbitform() {
            this.falidateForm();
            if (this.errors.length === 0)
                this.$emit('sumbitform', this.tag);
        },
        falidateForm() {
            this.errors = [];

            if (this.tag.name === "") {
                this.errors.push('Требуется указать имя.');
            }
        }
    }
}
</script>

<style lang="scss" scoped></style>