<template>
    <div id='actor'> 
        <div class='column'>
            <div class='left_column'>
                <img :src="actor.ImageUrl | fullUrl" alt='Image'>
                </div>
             <div class='right_column'>
                    <div> {{ actor }} </div>
                     
            </div>
        </div>
            <div class='banner'> <h2> Acted in </h2></div>
            <grid :items='actorCredits'></grid>
    </div>
</template>
<script>
    import Vue from 'vue';
    import { mapState } from 'vuex';
    import { store } from '../store/store'
    import Grid from '../components/grid'

    export default {
        data() {
            return {
                 birthDate: 'Unknown',
                 deathDate: '-',
                 desc: 'No information available', 
            }
        },
        computed: {
            ...mapState(['actor', 'actorCredits']), 
        },
        created() {
            store.dispatch('fetchActorCredits')
        },
        beforeRouteEnter (to, from, next) {
            if(store.state.actorId === 0) {
                next('home')
            } else {
                store.dispatch('fetchActor')
                .then(response => next())
                .catch(error => next(false))
            }
        },
        components: {
            Grid
        }

} 


</script>
<style scoped>

    #aaa {
        font-family: 'Roboto';
        margin-top: 16em;
    }

    .column {
        display: flex;
        height: 100%;
        padding-top: 2em;
        justify-content: left;
        background-color: #F5F3F3;
      
    }

    .banner {
        border-top: 1px solid black;
        border-bottom: 1px solid black;

        text-align: center;
    }

    .left_column {
        margin-left: 20%;
      
    }

    .left_column img {
        margin-left: 1em;
        width: 18em;
        height: 21em;
        border-radius: 7px;  
    }

    .right_column {
      margin-top: 4em;
      margin-left: 2em;
    }

</style>