<!-- A component that presents information about an actor or movie
     Has two modes, regular or mini.

     In regular mode a picure is placed in the left column, and info in the right.
     Possible info is title, rating, a date, director, genre and and overview.
     These are accessible as named slots (expect picture which must be attached as a prop)

     In mini mode we view the whole card as a column, where the picture is on top
     and the info to the bottom. Overview is not suported in this mode.

     Arguably this could have been split into two diferent card, but its an attempt two
     play around/resuse a component in differents shapes.
-->


<template>        
    <div id='bigcard' :class="{'bigcard' : !mini, 'mini' : mini}">
        <div :class="{'row' : !mini, 'mini_col' : mini}">
            <div id='left_col'>
                <img :src="imageUrl" alt='Image'>
            </div>
            <div class='right_column'>
                    <h1 v-if='!mini'>
                        <slot name='title'></slot>
                    </h1>
                      <div v-if='hasRating()'>
                         <div class='align'>
                            <img class='star' src='../assets/star.png' alt='Star'>
                            <h2>
                                <slot name='rating'></slot> 
                            </h2>
                        </div>
                    </div>
                    <h2 v-if='mini'> 
                        {{ miniTitle }}
                    </h2>
                    <h3 class='slim'>
                        <slot name='date'></slot> 
                        <slot name='director'></slot>
                        <slot name='genre'></slot>
                    </h3> 
                    <div v-if='hasOverView()'>
                        <h2>Overview</h2>
                        <p class='slim'> 
                            <slot name='overview'></slot>
                        </p>
                    </div>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        data() {
            return {
                miniTitle: String
            }
        },
        props: {
            imageUrl: {
                type: String,
                default: ''
            },
            mini: {
                type: Boolean,
                default: false
            }
        },
        methods: {
            hasRating() {
                return this.$slots.rating
            },
            hasOverView() {
                return this.$slots.overview
            }
        },
        // Id we're in mini mode the title is put under the rating
        created() {
            if(this.mini) {
                this.miniTitle = this.$slots.title[0].children[0].text
            }
        }

    }
</script>
<style scoped>

    /* CSS for the big card */

    .bigcard {
        display: block;
        height: 100%;
        background-color: #F1F1F1;
        border-radius: 1.5%;
        padding: 2%;
    }

    .row {
        align-self: center;
        justify-content: left;  
        margin: 0 2%;
    }

   #left_col {
        margin-top: 2%;
    }

    #left_col img {
        max-width: 100%;
        border-radius: 2%;  
    }

    .right_column {
        color: #303034;
        flex: 1;
        text-align: left;
        margin-left: 5%;
        margin-top: 5%;
    }

    .star {
       width: 6%;
       margin-top: 3.2%;
       margin-right: 1.5%;
    }   

    /* Contains the star and the rating, puts them in 
       a row and aligns theire height */


    .align {
        display: flex;
        justify-content: flex-start;
        align-items: center;
        height: 20%;
    } 

    .slim {
        font-weight: 300;
    }

    h1, h2 {
        margin-bottom: 0;
    }

    /* CSS for mini mode */

    .mini {
        width: 100%;
        height: auto;
    }

    .mini_col {
        font-size: 80%;
        border-radius: 7px;
     
    }

    .mini_col .star {
        margin-top: 5%;
        width: 12%;
    }

    .mini_col .align {
        margin-top: -1.2rem;
        margin-bottom: -0.8rem;
        font-style: oblique;
    }

</style>