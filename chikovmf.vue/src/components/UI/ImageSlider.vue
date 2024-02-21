<template>
    <div v-if="images">

        <div id="carouselExampleSlidesOnly" class="carousel carousel-dark border slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item" v-for="image in images" :class="{ active: this.isActive(image.projectImageId) }">
                    <img :src="image.src" :alt="image.alt" class="d-block w-100">
                </div>
            </div>

            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev"
                v-on:click="onPrev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next"
                v-on:click="onNext">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>

    </div>
</template>

<script>
export default {
    name: "ImageSlider",
    data() {
        return {
            activeSlideIndex: 0,
            slideCount: 0
        }
    },
    props: {
        images: {
            type: Array,
            required: true
        }
    },
    methods: {
        onNext() {
            if (this.activeSlideIndex >= this.slideCount - 1) {
                this.activeSlideIndex = 0;
            }
            else {
                this.activeSlideIndex++;
            }
        },
        onPrev() {
            if (this.activeSlideIndex <= 0) {
                this.activeSlideIndex = this.slideCount - 1;
            }
            else {
                this.activeSlideIndex--;
            }
        },
        isActive(imageId) {
            if (imageId == this.images[this.activeSlideIndex].projectImageId) {
                return true;
            }
            return false;
        }
    },
    created() {
        this.slideCount = Object.keys(this.images).length;
    }
}
</script>

<style lang="css" scoped>
</style>