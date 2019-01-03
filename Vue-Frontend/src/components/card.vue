<template>
    <div id='card' @click='clicked'>
        <img :src="img" alt='Picture'>
        <div class='textbox'>
            <div class='title'>
                <slot name='title'></slot>
            </div>
            <div class='subtitle'>
                <slot name='subtitle'></slot>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        props: {
           id: Number,
           type: String,
           img: String
        },
        methods: {
            clicked() {
                this.$emit('cardClicked', {
                    Id: this.id,
                    Type: this.type
                })
            }
        }
    }    
</script>
<style scoped>
    #card {
        display: flex;
        width: 30em;
        border: 2px solid #DEF2FB;
        border-radius: 3px;
        box-shadow: 1px 1px #3DBAF1;
        margin: 1% 1%;
    }

    #card img {
       width: 15%;
       height: 100%;
       border-radius: 3px;
    }

    .textbox {
        margin: 1em auto 0 1em;
        color: #343434;
    }

    .title {
        font-size: 1.2em;
    }

    .subtitle {
        font-style: oblique;
        padding-top: 5px;
        font-size: 1em;
    }
</style>
