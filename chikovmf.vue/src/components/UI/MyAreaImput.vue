<template>
    <textarea :value="modelValue" @input="updateInput" class="form-control" />
</template>

<script>
export default {
    name: 'MyAreaImput',
    props: {
        modelValue: [String, Number]
    },
    methods: {
        updateInput(event) {
            this.$emit('update:modelValue', event.target.value)
        }
    }
}
</script>

<style lang="scss" scoped></style>