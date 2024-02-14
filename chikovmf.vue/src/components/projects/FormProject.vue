<template>
    <form class="row row-cols-lg-auto g-3 align-items-center" id="projectForm" @submit.prevent="sumbitform">

        <div class="input-group col-12">
            <label class="input-group-text" for="name">Название</label>
            <input class="form-control" type="text" id="name" v-model="project.name" name="name" />
        </div>

        <div class="input-group col-12">
            <label class="input-group-text" for="description">Описание</label>
            <textarea class="form-control" id="description" v-model="project.description" name="description"></textarea>
        </div>

        <div class="input-group col-12">
            <label class="input-group-text" for="content">Содержание</label>
            <textarea class="form-control" id="content" v-model="project.content" name="content"></textarea>
        </div>
        
        <div class="input-group col-12">
            <input class="form-control" type="file" id="cardImage" @change="onUploadCardImage" name="cardImage" accept="image/png, image/jpeg" />
        </div>
        
        <TagSegment :tags="project.tags" />

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
import TagSegment from './TagSegment.vue';

export default {
    data() {
        return {
            errors: [],
            cardImage: null
        };
    },
    props: {
        project: {
            type: Object,
            required: true,
        },
    },
    methods: {
        sumbitform() {
            this.falidateForm();
            if (this.errors.length === 0)
                this.$emit('sumbitform', this.project, this.cardImage);
        },
        falidateForm() {
            this.errors = [];
            if (this.project.name === "") {
                this.errors.push('Требуется указать название.');
            }
            if (this.project.description === "") {
                this.errors.push('Требуется указать описание.');
            }
            if (this.project.content === "") {
                this.errors.push('Требуется указать содержание.');
            }
        },
        onUploadCardImage(event) {
            this.cardImage = event.target.files[0];
        }
    },
    components: { TagSegment }
}
</script>

<style lang="scss" scoped></style>