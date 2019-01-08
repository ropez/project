<!--
    A searchbar. Takes a placeholder text as a prop. Routes to the result 
    page with the query string as a query parameter.
-->


<template>
    <div id='searchbar'>
        <input class='bar position'
            v-model='query'  
            type='text' 
            :placeholder='placeHolder'
            @keyup.enter='performSearch'>
    </div>
</template>
<script> 
    export default {
        props: {
            placeHolder: {
                type: String,
                default: 'Search..'
            }
        },
        data() {
            return {  
                query: '',
            }
        },
        methods: {
            performSearch() {
                if(this.query.trimStart().length === 0)
                    return

               this.$router.push({ name: 'result', query: { key: this.query, pageNum: 1}})
               this.query = ''          
        }, 
    }
}

</script>
<style scoped>

    #searchbar  {
        background-color: white;
    }

    .position {
        position: relative;
        padding-left:2.5rem;
        text-indent:2rem;
        font-family: sans-serif, Arial, Helvetica;
        font-style: oblique;
        font-weight: 200;
        width: 60%;
        margin: 0 10%;
    }

   .bar[type=text] {
        background: url('../assets/icons8-search-50.png');
        background-size: 1.2em;
        background-repeat: no-repeat; 
        background-position: 0% 50%;
        padding: 10px;
        font-size: 1.2em;
        border: none;
        outline: none;
        background-color: white;
    }

</style>

