<!--
    A component that performs a search request API and displays the result.
    Shows a summary: search key, number of maches, and number of pages of results.
    And a column of results where each result is displayed as a result card,

    The cards are wrapped in a router link so they link to their own details page.

    This page uses the Pagination component.
-->


<template>
    <div id="result"> 
            <div class='row'>
                <div class='column col_spacing'>
                    <div class='info'>Search: '{{key}}'</div>
                    <div class='info'>Total matches: {{ numMatches }}</div>
                    <div class='info'>Total pages: {{ maxPages }} </div>
                </div>
                <div class='column'>       
                    <router-link v-for='(item, i) in searchResult' :key='i' :to='{name: item.Type, params: { id: item.Id }}'>
                        <result-card :img='item.Img | getFullUrl'>
                            <div slot='title'> {{item.Key}}</div>
                            <div v-if='item.Type === "movie"' slot='info'>Released {{ item.Date | formatDate }} </div>
                            <div v-if='item.Type === "actor"' slot='info'>Actor </div>
                        </result-card>
                    </router-link>
                </div>
            </div>
            <div class='center' v-if='maxPages > 1' >
                    <pagination :maxPage='maxPages'
                        :curPage='curPageAsNum()'
                        :visiblePages='configVal()'
                        @pageClicked='pageButtonClicked'>
                   </pagination>
            </div>
    </div>
</template>  
<script>
    import { appConfig } from '../div/Config';
    import { httpRequest } from '../div/HttpRequest';
    import ResultCard from '../components/ResultCard';
    import Pagination from '../components/Pagination';

    export default {
        data() {
            return {
                key: '',
                numMatches: Number,
                searchResult: JSON,
                curPage: Number
            }  
        },
        computed: {
             maxPages() {
                return Math.ceil(this.numMatches / appConfig.pageSize)
            }, 
        },
        methods: {
            // Receives a message/clicked page number from Pagination.
            // Routes to this (SearchhResult) compoonent with the pagenumber and search key
            pageButtonClicked(pageNum) {
                this.$router.push({ name: 'result', query: { key: this.key, pageNum: pageNum }})
            }, 
            /*
                Convenience method for setting data from the Http request.
            */
            setData(key, pageNum, searchResult, numMatches) {
                this.key = key
                this.searchResult = searchResult
                this.numMatches = numMatches
                this.curPage = pageNum
            },
            /*
                If the user clicks the url/adress in the browser, the pageNumber is returned as a string.
                We must therefore check this, and convert it. And if its not a valid number, we just
                return page 1.
            */
            curPageAsNum() {
                if(typeof this.curPage === 'number') return this.curPage

                let integer = 1
                try {
                    integer = parseInt(this.curPage, 10);
                } catch (e) {
                    console.log(e)
                }

                return integer
                   
            },
            configVal() {
                return appConfig.numSearchNavButtons
            }

        },
        components: {
            Pagination,
            ResultCard
        },
        /*
        * This component can be routed to by other components and from itself. When routed to by other components
        * its created, and beforeRouteEnter is called. When routed to by itself the component is reused, beforeRouteEnter is
        * therefore not called, and we need to do the get request in beforeRouteUpdate.
        *
        */
        beforeRouteEnter(to, from, next) {
            httpRequest.fetchSearch(to.query.key, to.query.pageNum)
                .then(response => {
                    next( vm => {
                        vm.setData(to.query.key, to.query.pageNum, response.body.Page, response.body.Count) 
                    })
                })
                .catch(error => { 
                    alert('An error occured trying to retrieve data from the server.')
                    next(false)
                })   
        },
        beforeRouteUpdate(to, from, next) {
            httpRequest.fetchSearch(to.query.key, to.query.pageNum)
                .then(response => {
                    this.setData(to.query.key,to.query.pageNum, response.body.Page, response.body.Count) 
                    next()
                })
                .catch(error => { 
                    alert('An error occured trying to retrieve data from the server.')
                    next(false)
                })       
        }
    }
</script> 
<style scoped> 

    #result {
        margin-top: 16em;
    }
    .info {
        border-bottom: 3px solid lightblue;
        padding: 4% 0 4% 0;
        font-style: oblique;
        width: 12em;
        font-size: 1.3em;
    }

    .col_spacing {
      margin: 0% 8% 0% 20%;
    }

    .center {
        display: flex;
        justify-content: center;
        margin-top: 1.5em;
    }

</style>