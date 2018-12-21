<template>
    <div>
        <div class="header">
            <h1 class="center-text"> A header</h1>
            <h3 class="center-text">Smaller text. Dumb Catchy slogan.</h3>
        </div>
            <search-bar></search-bar>
    </div>
</template>
<script>
    import SearchBar from './SearchBar';
    export default {
        data() {
            return {}
        },
        components: {
            SearchBar
        }
    };
</script>
<style scoped>
    h1, h3 {
        color: #fff;
        margin: 0 0;
    }
    .header {
        width: 100%;
        height: 12em;
        background-image: linear-gradient(54deg, #04496e, #000, #00f);
    }
</style>