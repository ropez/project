<template>
    <div id='pagination'>
        <ul>
            <div class='show' :class='{hide: curPage == 1}'>
                <button class='btn' @click='pagePrevious'>Previous</button>
            </div>
            <div v-for='page in pages' :key='page.pageNum'>  
                    <li>
                        <button class='btn' :class='{"current" : page.isDisabled}' 
                                @click='pageClicked(page.pageNum)'
                                :disabled='page.isDisabled'>
                            {{ page.pageNum }}
                        </button>
                    </li>
            </div>
            <div class='show' :class='{hide: curPage == maxPage}'>
                <button class='btn' @click='pageNext'>Next</button>
            </div>
        </ul>

    </div>
</template>
<script>
    export default {
        props: {
                maxPage: Number,
                visiblePages: Number,
                curPage: Number,
        },
        computed: {
            pages() {
                const range = []

                for (let i = this.startPage; i <= Math.min(this.visiblePages + this.startPage, this.maxPage); i += 1) {
                    range.push({
                        pageNum: i,
                        isDisabled: i === this.curPage
                    })
                }
                return range;
            },
            startPage() {

               let startPage;
                if (this.maxPage <= this.visiblePages) 
                      startPage = 1
                else if (this.curPage + this.visiblePages > this.maxPage) 
                    startPage =  this.maxPage - this.visiblePages  + 1
                else
                    startPage = this.curPage

                return startPage;    
            },    
            
        },
        methods: {
            pageNext() {
                this.$emit('pageClicked', this.curPage + 1)
            },

            pagePrevious() {
                this.$emit('pageClicked', this.curPage - 1)
            },
            pageClicked(pageNum) {
                this.$emit('pageClicked', pageNum)
            },
        }
    }
</script>
<style>
    #pagination ul {
        display: flex;
        list-style-type: none;
    }

    .show {
        visibility: visible;
    }

    .hide {
        visibility: hidden;
    }

    .btn, .current {
        border: none;
        color: #343434;
        font-size: 1.2em;
        margin: auto 0.5em;
        outline: none;
    }

    .current {
        border-bottom: 2px solid  #3DBAF1;
    }

</style>