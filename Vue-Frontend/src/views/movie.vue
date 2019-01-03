<template>
    <div id='movie'> 
        <div class='column'>
            <div class='left_column'>
                <img :src='movie.PosterUrl | fullUrl' alt='Image'>
                </div>
             <div class='right_column'>
                    <div> {{ movie }} </div>
                     
            </div>
        </div>
            <div class='banner'> <h2> Acted in </h2></div>
            <grid :items='movieCredits'></grid>
       
    </div>
</template>
<script>
    import Vue from 'vue'
    import Grid from '../components/grid'
    import { mapState } from 'vuex';
    import { store } from '../store/store';

    export default {
        data() {
            return {
            
            }
        },
        computed: {
            ...mapState(['movie', 'movieCredits'])
        },
        components: {
            Grid
        },
        created() {
           store.dispatch('fetchMovieCredits')
        },
        beforeRouteEnter (to, from, next) {
            if(store.state.movieId === 0) {
                next('home')
            } else {
                store.dispatch('fetchMovie')
                    .then(response => next())
                    .catch(error => next(false))
            }
        }      
    }

</script>
