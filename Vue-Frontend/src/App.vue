<template>
  <div id="app">
      <app-header></app-header>
      <router-view></router-view>
      <app-footer></app-footer>  
  </div>
</template>
<script>
    import Header from './components/header';
    import Footer from './components/footer';

    export default {
      components: {
        appHeader: Header, 
        appFooter: Footer,
      }
    }
</script>
<style>

    body {
        margin: 0;
        padding: 0;
        width: 100%;
        height: 100%;
        font-family: 'Roboto';
    }

    .row {
        display: flex;
    }

    .column {
        flex-direction: column;
    }   
</style>