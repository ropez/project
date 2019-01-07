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
                <router-link v-for='(movie, i) in credits' :key='i' :to='{name: movie.Type, params: { id: movie.Id }}'>
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
        created() {
           httpRequest.fetchActorCredits(this.$route.params.id)
                        .then(response => this.credits = response.body)
        },
        beforeRouteEnter(to, from, next) {
            httpRequest.fetchActor(to.params.id)
                .then(response => {
                    if(response.status === 204) {
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

