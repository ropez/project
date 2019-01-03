<template>
        <div id='header'>
            <div class='logo'>
                <img src='../assets/logo.png' alt='Logo Image'>
                <div id="nav">
                    <ul>
                        <li @click='toggleNews' v-on-clickaway="closeNews"> 
                            News
                            <div class='dropdown' :class='{"open" : newsOpen}'>
                                No content
                            </div>
                        </li>
                        <li @click='toggleAbout' v-on-clickaway="closeAbout">
                            About
                            <div class='dropdown' :class='{"open" : aboutOpen}'>
                                No content
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
            <search-bar placeHolder='Find your new favourite movie or actor...'>
            </search-bar>
        </div>
        
</template>
<script> 
    import SearchBar from './searchbar';
    import { directive as onClickaway } from 'vue-clickaway';

    export default {
        data() {
            return {
                newsOpen: false,
                aboutOpen: false,
            }
        },
        methods: {
            toggleAbout() {
                this.aboutOpen = !this.aboutOpen
            },
            toggleNews() {
                this.newsOpen = !this.newsOpen
            },
            closeNews() {
                this.newsOpen = false;
            },
            closeAbout() {
                this.aboutOpen = false;
            }
        },
        components: {
            SearchBar
        },
        directives: {
            onClickaway: onClickaway,
        },
    }    

    //search bar: align-item.: flex end; in y dir. eller align-self
</script>
<style scoped>

    #header {
        position: fixed;
        width: 100%;
        top: 0;
        border-bottom: 1em solid #3DBAF1;
    }


    .logo {
        display: flex;
        height: 10em;
        background-color: #3DBAF1;
    }
    
    .logo img {
        margin-left: 3em;
        height: 10em;
        width: 30em;
    }

    #nav ul {
        margin: 3.6em auto auto 43em;
        list-style-type: none;
        display: flex;
    }

    #nav ul li {
        margin: 0 0.6em;
        font-size: 1.2em;
        color: white;
        transition: font-size 200ms;
    }

    #nav ul li:hover {
        margin: 0 0.6em;
        font-size: 1.5em;
    } 

    .dropdown {
        border: 1px solid;
        border-radius: 4px;
        width: auto;
        height: auto;
        visibility:collapse;
        position: absolute;
        opacity: 0;
        background-color: #3DBAF1;
        transition: opacity 0.5s;
        margin-top: 0.2em;
    }

    .open {
        visibility: visible;
        opacity: 100;
    }
</style>
