 <template>
    <div id='grid'>
        <card v-for='item in items' :key='item.Id' 
                :id='item.Id'
                :type='item.Type'
                :img='item.Img | fullUrl' 
                @cardClicked='route'>
                <div slot='title'>{{ item.Key }}</div>
                <div v-if='isActor(item)' slot='subtitle'>Actor</div>
                <div v-else slot='subtitle'>Released : {{ item.Date }}</div>     
        </card>  
    </div>   
</template> 
<script>

    import Card from './card';
    import { store } from '../store/store' 

    export default {
    props: ['gridstyle', 'items'],
    data() {
        return {
        } 
    },
    methods: { 
        route({Id, Type}) {

            const route = Type
            store.dispatch('setId', { id: Id, type: Type})
            console.log('grid called action: '  + Id + ' ' + Type)
            // hent fra en config fil route til actor
            this.$router.push(route)
        },
        isActor(item) {
            return item.Type === 'actor'
        }
    },
    components: {
            Card            
        }
    }
</script>