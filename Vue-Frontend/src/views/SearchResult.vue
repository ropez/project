<template>
    <div id="result"> 
        <a id='top'></a>
        <div class='row'>
             <div class='column col_spacing'>
                <div class='info'></div>
                <div class='info'>Total matches: {{ numMatches }}</div>
                <div class='info'>Total pages: {{ maxPages }} </div>
            </div> 
            <div class='column'>
                <grid :items='searchResult'></grid>
            </div>
        </div>
        <div class='center'>
                <pagination :maxPage='maxPages'
                            :curPage='curPage'
                            :visiblePages='10'
                            @pageClicked='pageClicked'
                ></pagination>
            </div>
    </div>
</template>  
<script>
    import { appSettings } from '../Settings';
    import { mapState } from 'vuex';
    import { mapActions } from 'vuex';
    import { store } from '../store/store';
    import Grid from '../components/grid';
    import Pagination from '../components/pagination';

    export default {
        data() {
            return {
                curPage: 1
            }
        },
        computed: {
             ...mapState(['searchResult',  
                          'numMatches']
            ),
            maxPages() {
                console.log('maxPages: ' + Math.ceil(this.numMatches / appSettings.pageSize))
                return Math.ceil(this.numMatches / appSettings.pageSize)
            }, 
        },
        methods: {
            ...mapActions(['search']),
            pageClicked(pageNum) {
                console.log('pageclicked: ' + this.searchKey + ' ' + this.curPage)
                this.curPage = pageNum

                this.search({
                    pageNum: pageNum,
                })
            }
        },
        components: {
            Pagination,
            Grid,
        },
        created() {
                
        },
        beforeRouteEnter(to, from, next) {
            if(store.state.searchKey.length === 0) {
                next('home')
            } else {
                next()
            }
        }
    }
</script> 
<style scoped> 

    #result {
        margin-top: 16em;
    }
    .info {
        border-bottom: 2px solid #3DBAF1;
        color: #343434;
        padding: 2% 0 2% 0;
        font-style: oblique;
        width: 12em;
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