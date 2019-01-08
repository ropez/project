<!-- The home page for the app
     show a 'landing' image with some text, and below
     some oldies but goldies/higly rated movies from the dtaabase.

     The movies are wrapped in router links.
-->

<template>
    <div id='home'>
        <div class='landing'>
            <div class='text'>
                Always on the lookout
                <div class='margin'>for the next good movie..</div>
            </div>
        </div>
        <div class='bar'>Oldies but goldies</div>
        <div class='grid_six_col'>
            <router-link class='grid_padding' v-for='(movie, i) in movies' :key='i' :to='{name: "movie", params: { id: movie.Id}}'>
                 <profile-card :mini='true'  :imageUrl="movie.PosterUrl | getFullUrl"> 
                            <div slot='title'> {{ movie.Title }}</div>
                            <div slot='rating'>{{ movie.Rating }} </div>
                            <div slot='genre'>{{ movie.Genres | arrayToList }} </div>
                </profile-card> 
            </router-link>                 
        </div>
    </div>
</template>
<script>
    import { appConfig } from '../div/Config';
    import { httpRequest } from '../div/HttpRequest';
    import ProfileCard from '../components/ProfileCard';

    export default {
        data() {
            return {
                movies: JSON
            }
        },
        components: {
            ProfileCard
        },
        // We only need to fetch data when this page is created, since the data is static (We only
        // retrieve a certain number of highly rated movies and thats that). If the user clicks
        // the home button when on the home page, there's nothing to update.
        created() {
           httpRequest.fetchPopular(1)
                        .then(response => {
                            this.movies = response.body
                            console.log(response)
                        })
                        .catch(error => { 
                             alert('An error occured trying to retrieve data from the server.')
                        })   
        },
    }
</script>


<style scoped>
    #home {
        display: flex;
        flex-direction: column;
        margin-top: 13em;
        width: 100%;
        height: auto;
    }

    /* Landing image and text */

    .landing {
        flex: 2;
        display: flex;
        justify-content: center;
        background: url('../assets/gal.jpg');
        background-repeat: no-repeat;
        background-size: cover;
        height: 40rem;   
    }

    .text {
        width: 60rem;
        font-size: 4rem;
        font-weight: 100;
        color: white;
        font-style: oblique;
        margin: 10rem 10rem;
        white-space: nowrap;
    }

    .margin {
        margin-left: 3em;
    }

    /* Grid of movies */

    .grid_padding {
        margin: 1% 1%;
    }

    .grid_six_col {
        flex: 0.5;
        display: grid;
        grid-template-columns: repeat(5, 12rem);
        margin: auto auto;
    }

    /* Seapration bar between landing image and movies grid*/

    .bar {
        display: flex;
        justify-content: center;
        align-items: center;
        font-weight: 100;
        font-size: 2.5rem;
        color: black;
        margin: 2rem auto;
        border-top: 0.2rem solid black;
        border-bottom: 0.2rem solid black;
    }



</style>