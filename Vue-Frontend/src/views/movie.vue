<!--
    A componnet/page that shows details about an movie. Uses the component
    PresentationCard to display the info. 

    A list of all the actors in the movie and their played characters are also showed. These
    are presented using ResultCards.

    The resultCards (movies) are made clickable by enclosing them in a router link,
    so that they route to their own details page.

    The movie and the actor page are very similar, so one could arguably had made a another
    component, where one just filled in the actor/movie data into, and then drop the actor and
    movie component.

    Formatting of data in this component is mainly done by filters, as the same formatting also
    has to be done in the resultcards when we display search results, and in the 'mini' profile cards.
-->


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
            <router-link class='grid_two_col' v-for='(actor, i) in credits' :key='i' :to='{name: "actor", params: { id: actor.Id }}'>
                        <result-card :img='actor.Img | getFullUrl'>
                            <div slot='title'> {{actor.Key}}</div>
                            <div slot='info'>as {{actor.Character}}</div>
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

        /*
            Follows the same lofic as in the Actor component.
        */
        created() {
             httpRequest.fetchMovieCredits(this.$route.params.id)
                    .then(response => this.credits = response.body)   
        },
        beforeRouteEnter(to, from, next) {
            httpRequest.fetchMovie(to.params.id)
                .then(response => {
                    if(response.status != 200) {
                        next(false)
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
