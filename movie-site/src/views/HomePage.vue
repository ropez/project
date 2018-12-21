<template>
    <div>
        <page-header></page-header>
        <card-grid v-if="showGrid"></card-grid>
        <div v-else>No results found</div>
    </div>
</template>
<script>
    import PageHeader from "../components/PageHeader";
    import Grid from "../components/Grid"
    import { eventBus } from "../main";

    export default {
        data() {
            return {
                showGrid: true
            }
        },
        components: {
            PageHeader,
            cardGrid: Grid
        },
        created() {
            eventBus.$on('hasElements', (status) => {
                this.showGrid = status
            });
        }
    };
</script>
<style>
</style>