<template>
    <div>
        <grid-card v-for="elem in gridElems" :key="elem"> 
            {{ elem }}
        </grid-card>
    </div>
</template>
<script>
    import Card from './Card';
    import  { eventBus } from '../main';

    export default {
        data() {
            return {
                gridElems: []
            }
        },
        components: {
            GridCard: Card
        },

        created() {
              eventBus.$on('searchCompleted', (data) => {
                this.gridElems = data
            }); 
        }
    };
</script>
<style scoped>
</style>