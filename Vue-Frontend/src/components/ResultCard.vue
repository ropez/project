
<template>
    <div id='card'>
        <img :src='img' alt='Image'>
        <div class='textbox'>
            <div class='title'>
                <slot name='title'></slot>
            </div>
            <div class='info'>
                <slot name='info'></slot>
            </div>
        </div>
    </div>
</template>
<script>
    export default {
        props: ['img']
    }
</script>
<style scoped>
    #card {
        display: flex;
        width: 24em;
        height: 6.9em;
        background: rgb(255,255,255);
        background: linear-gradient(165deg, rgb(255, 255, 255) 68%, rgba(87,238,237,0.1292892156862745) 82%, rgba(0,62,159,0.10968137254901966) 93%);
        border: 1px solid  #303034;
        border-radius: 5px;
        box-shadow: 1px 1px grey;
        margin: 2% 2%;
    }

    #card img {
       height: 100%;
       width: 20%;
       border-radius: 2px;
    }

    .textbox {
        margin: 1em auto 0 1em;
        color: #303034;
    }

    .title {
        font-size: 1.4em;
    }

    .info {
        font-style: oblique;
        padding-top: 5px;
        font-size: 1.2em;
    }
</style>
