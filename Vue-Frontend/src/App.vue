<!--
    The header and footer components are always alive.
    The other views are inserted into the router-view
    between them.
-->

<template>
  <div id="app">
      <app-header></app-header>
      <router-view></router-view>
      <app-footer></app-footer>  
  </div>
</template>
<script>
    import Header from './components/Header';
    import Footer from './components/Footer';

    export default {
      components: {
        appHeader: Header, 
        appFooter: Footer,
      }
    }
</script>
<style>

    /*
        Various App wide CSS settings
    */

     body {
        margin: 0;
        padding: 0;
        width: 100%;
        height: 100%;
        font-size: 100%;
        font-family: Arial, sans-serif;
    }
    
    p {
        font-size: 1.2rem;
    }

    a {
        text-decoration: none;
    }


    .row {
        display: flex;
    }

    .col {
        flex: 1;
    }

    .column {
        flex-direction: column;
    }   

    .banner {
        margin-top:2em;
        justify-content: center;
        align-items: center;
        height: 3em;
        display: flex;
        color: #343434;
        font-size: 1.1em; 
        
    }

    .grey {
        background-color: #E3E3E3;
        color: black; 
        border: 1px solid  #A6A6A6;
        
    }

     .grid_two_col {
        display: grid;
        grid-template-columns: auto auto;
        justify-content: center;
        grid-column-gap: 0.5rem;

    }

    .grid_container {
        margin: 2% 20% 2% 20%;
    }

    .presentation_container {
        width: 60em;
        margin: 0 auto;

    }
</style>