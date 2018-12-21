<template>
    <div style="width: 100%">
        <input type="text" placeholder="Search for movie or actor..">
        <button @click="performSearch">search</button>     
    </div>
</template>
<script>
    import { eventBus } from '../main';
    export default {
        data() {
            return {}
        },
        methods: {
            performSearch() {
                console.log("searchCompleted")
                var res = ["tage", "per", "lars"]
                eventBus.$emit('searchCompleted', res)
    
                if(res.length > 0) {
                    eventBus.$emit('hasElements', true)
                } else {
                    eventBus.$emit('hasElements', false)
                }
            }
        }
    };
</script>
<style>
</style>