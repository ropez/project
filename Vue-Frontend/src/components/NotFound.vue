
<!--
     A simple notfound page which we route to if the user messes with the url 
     or if an error occurs
-->

<template>
<div id='notfound'>
    <img src='../assets/cry.png' alt='Crying smiley'>
    <h1 class='below_header'>Ups.. We can't find the page you are looking for...</h1>
    </div>
</template>
<style scoped>


    #notfound {
        display: flex;
        flex-direction: column;
        align-items: center;
        margin-top: 16rem;
        width: 100%;
        height: 100%;
    }

    #notfound img {
        width: 20rem;
    }


    .below_header {
     
        color: rgb(103, 104, 106);
    }
</style>