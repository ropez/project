<template>
    <div id='movie'> 
        <div class='presentation_container'>
            <profile-card :imageUrl="movie.PosterUrl | getFullUrl"> 
                    <div slot='title'> {{ movie.Title }} </div>
                    <div slot='date'> Released: {{ movie.Released | formatDate }} </div>
                    <div slot='overview'>{{ checkOverView() }} </div>
                    <div slot='rating'>{{ movie.Rating }} </div>
                    <div slot='director'>Director: {{ movie.Directors | arrayToList }}</div>
                    <div slot='genre'>Genre: {{ movie.Genres | arrayToList }}</div> 
            </profile-card>   
        </div>
        <div class='banner grey'> <h2>Credits</h2> </div>    
         <div class='grid_container'>
            <div class='grid_two_col'>
            <router-link class='grid_two_col' v-for='(actor, i) in credits' :key='i' :to='{name: actor.Type, params: { id: actor.Id }}'>
                        <result-card :img='actor.Img | getFullUrl'>
                            <div slot='title'> {{actor.Key}}</div>
                            <div slot='info'>Actor</div>
                        </result-card>
                        
                </router-link>
            </div>
        </div>

    </div>
</template>
<script>
    import Vue from 'vue';
    import { httpRequest } from '../div/HttpRequest';
    import ResultCard from '../components/ResultCard';
    import ProfileCard from '../components/ProfileCard';

    export default {
        data() {
            return {
                movie: JSON,
                credits: JSON
            }
        },
        methods: {
            checkOverView() {
                return this.movie.Description === "" ? 'No information available.' : this.movie.Description
            },
         
        },
        components: {
           ResultCard,
           ProfileCard
        }, 
        created() {
             httpRequest.fetchMovieCredits(this.$route.params.id)
                    .then(response => this.credits = response.body)   
        },
        beforeRouteEnter(to, from, next) {
            httpRequest.fetchMovie(to.params.id)
                .then(response => {
                    if(response.status == 204) {
                        next('notfound')
                    }
                    next(vm =>  vm.movie = response.body[0])
                })
                .catch(error => { 
                    alert('An error occured trying to retrieve data from the server.')
                    next(false)
                })   
        },       
    }
</script>
<style scoped> 
    #movie {
        margin-top: 16em;
    }
</style>
