<template>
    <div id='pagination'>
        <ul>
            <div class='show' :class='{hide: curPage == 1}'>
                <button @click='pagePrevious'>Previous</button>
            </div>
            <div v-for='page in pages' :key='page.pageNum'>  
                    <li :class='format'>
                        <button @click='pageClicked(page.pageNum)'
                                :disabled='page.isDisabled'>
                            {{ page.pageNum }}
                        </button>
                    </li>
            </div>
            <div class='show' :class='{hide: curPage == maxPage}'>
                <button @click='pageNext'>Next</button>
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
                format: String
        },
        computed: {
            startPage() {

                 if(this.maxPage < this.visiblePages)
                    this.visiblePages = this.maxPage

                let startPage;
                if (this.curPage === 1) 
                      startPage = 1
                else if (this.curPage === this.maxPage) 
                    startPage =  this.maxPage - this.visiblePages;
                else
                    startPage = this.curPage - 1
                
                return startPage;
                
            },

            pages() {
                const range = []
                for (let i = this.startPage; i <= Math.min(this.visiblePages + this.curPage - 1, this.maxPage); i += 1) {
                    range.push({
                        pageNum: i,
                        isDisabled: i === this.curPage
                    })
                }
                return range;
            }
        },
        methods: {
            pageNext() {
                this.$emit('pageClicked', this.curPage + 1)
            },

            pagePrevious() {
                this.$emit('pageClicked', this.curPage - 1)
            },
            pageClicked(pageNum) {
                console.log('pageClicked: ' + pageNum)
                this.$emit('pageClicked', pageNum)
            },
            created() {
               
            }
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

</style>