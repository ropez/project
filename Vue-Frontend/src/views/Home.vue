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

    .landing {
        flex: 2;
        display: flex;
        justify-content: center;
        background: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)), url('../assets/gal_gadot.jpg');
        background-repeat: no-repeat;
        background-size: cover;
        height: 40rem;   
    }

    .grid_padding {
        margin: 1% 1%;
    }

    .grid_six_col {
        flex: 0.5;
        display: grid;
        grid-template-columns: repeat(5, 12rem);
        margin: auto auto;
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

    .bar {
        display: flex;
        justify-content: center;
        align-items: center;
        font-weight: 100;
        font-size: 3rem;
        color: black;
        margin: 1rem auto;
    }



</style>