<template>
    <div style="width: 100%">
        <input v-model="query" type="text" placeholder="Search for movie or actor..">
        <button @click="performSearch">search</button>     
    </div>
</template>
<script>
    import { eventBus } from '../main';
    export default {
        data() {
            return {
                query: '',
                searchResult: []
            }
        },
        methods: {
            performSearch() {
                if(this.query.Length == 0) {
                    return;
                }

                 this.$http.get('search?key=' + this.query).then((response) => {
                    this.searchResult = response.data;
                    this.notify()
                
                });
            },
            notify() {
                eventBus.$emit('searchResult', this.searchResult)
    
            }
        }
    };
</script>
<style>
</style>