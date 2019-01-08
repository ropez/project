<!--
    A componnet/page that shows details about an actor. Uses the component
    PresentationCard to display the info. 

    A list of all the movies the actor has starred in is also showed. These
    are presented using ResultCards.

    The resultCards (movies) are made clickable by enclosing them in a router link,
    so that they route to their own details page.
-->

<template>
    <div id='actor'> 
        <div class='presentation_container'>
            <profile-card :imageUrl="actor.ImageUrl | getFullUrl">
                    <div slot='title'> {{  actor.Name }} </div>
                    <div slot='date'> {{ formatDateYear() }} </div>
                    <div slot='overview'>{{ checkOverView() }} </div>
            </profile-card>    
        </div>
        <div class='banner grey'> <h2> Acted in </h2></div>
        <div class='grid_container'>
            <div class='grid_two_col'>
                <router-link v-for='(movie, i) in credits' :key='i' :to='{name: "movie", params: { id: movie.Id }}'>
                        <result-card :img='movie.Img | getFullUrl'>
                            <div slot='title'> {{movie.Key}}</div>
                            <div slot='info'>Released {{ movie.Date | formatDate }} </div>
                        </result-card>        
                </router-link> 
            </div>
        </div>  
    </div>
</template>
<script>
    import Vue from 'vue';
    import { httpRequest } from '../div/HttpRequest'
    import ProfileCard from '../components/ProfileCard';
    import ResultCard from '../components/ResultCard';

    export default {
        data() {
            return {
                id: Number,
                actor: JSON,
                credits: JSON
            }
        },
        /*
            Formatting and checking the JSON response before outputting them.
        */
        methods: {
            checkOverView() {
                return this.actor.Description === "" ? 'No information available.' : this.actor.Description

            },
            formatDateYear() {
                let birthDeath = '(' + new Date(this.actor.BirthDate).getFullYear() + ' - '
                if(this.actor.BirthDate === null) birthDeath = '(Unknown - '
                if(this.actor.DeathDate != null) birthDeath += + new Date(this.actor.DeathDate).getFullYear()
                return birthDeath += ')'
            },
        },
        components: {
            ResultCard,
            ProfileCard,
        },

        /*
            Creating the API it seemed like a good idea to separate the actor and the movies he/she has
            starred in into separate calls for flexibility. Here we see that we should also had
            included the option of getting it all in one request.

            This component is only accessed from other components, it will therefore always be created.
            BefoforeRouteEnter and created gets called every time. We make the call for actor info here, and if 
            it fails we redirect to the notfound page. We call next(false) so that if the user clicks back 
            in the browser, he doesnt see an empty profile/details page. The most important thing is the
            actor info, so we make the credits call in created only if teh first get request succeded.
        */  
        created() {
           httpRequest.fetchActorCredits(this.$route.params.id)
                        .then(response => this.credits = response.body)
        },
        beforeRouteEnter(to, from, next) {
            httpRequest.fetchActor(to.params.id)
                .then(response => {
                    if(response.status != 200) {
                        next(false)
                        next('notfound')
                    }
                    console.log(response)
                    next(vm => vm.actor = response.body)
                })
                .catch(error => { 
                    alert('An error occured trying to retrieve data from the server.')
                    next(false)
                })   
        },
} 
</script>
<style scoped>
    #actor {
        margin-top: 16em;
    }

   
</style>

