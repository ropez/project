<template>
  <home-page></home-page>
</template>
<script>
  import HomePage from './views/HomePage';

    export default {
      name: 'App',
      components: {
        HomePage
      }
    }
</script>
<style>
    h1, h2, h3, p {
      font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
    }
    h1 {
      font-size: 4em;
    }
    h3 {
      font-size: 1em;
    }
    .center-text {
      text-align: center;
    }
</style>
