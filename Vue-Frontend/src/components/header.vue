<template>
        <div id='header'>
            <div class='logo'>
                <div class='no_stretch'>
                    <img src='../assets/logo.png' alt='Logo Image'>
                </div>
                <div id="nav">
                    <ul>
                        <router-link to='/'>
                             <li>Home</li>
                        </router-link>
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
            <div class='bottom'>
            </div>
        </div>
        
</template>
<script> 
    import SearchBar from './SearchBar';
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
        z-index: 10;
    }

    .logo {
        display: flex;
        height: 10em;
        background: rgb(0,212,255);
        background: linear-gradient(90deg, rgba(0,212,255,1) 1%, rgba(14,12,75,1) 64%, rgba(0,26,36,1) 99%);
    }
    
    .logo img {
        flex: 3;
        margin-left: 3em;
        height: 10em;
    }

    .bottom {
        width: 100%;
        height: 1em;
        background: linear-gradient(90deg, rgba(0,212,255,1) 1%, rgba(14,12,75,1) 64%, rgba(0,26,36,1) 99%);
    }


    .no_stretch {
        flex: 1;
        width: 30em;
    }

    a {
        text-decoration: none;
    }

    #nav ul {
        flex-basis: auto;
        list-style-type: none;
        display: flex;
        margin-right: 2em;
    }

    #nav ul li {
        margin: 1.5em 0.8em;
        font-size: 1.2em;
        color: white;
        line-height: 2em;
        text-shadow: 2px 2px black;
        transition: border-bottom 300ms;
    }

    #nav ul li:hover {
        border-bottom: 3px solid white;
    } 

    .dropdown {
        border: 1px solid;
        border-radius: 4px;
        width: auto;
        height: auto;
        visibility:collapse;
        position: absolute;
        opacity: 0;
        background-color: rgb(143, 156, 159);
        transition: opacity 0.5s;
        margin-top: 0em;
    }

    .open {
        visibility: visible;
        opacity: 100;
    }

</style>
