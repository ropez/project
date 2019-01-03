
import Vue from 'vue';
import Vuex from 'vuex';
import { mutations } from './mutations';
import { actions } from './actions';

Vue.use(Vuex);

export const store = new Vuex.Store({
    state: {
        searchResult: JSON,
        searchKey: '', 
        numMatches: 0,
        actor: JSON,
        movie: JSON,
        actorId: 0,
        movieId: 0,
        movieCredits: JSON,
        actorCredits: JSON
    },
    mutations,
    actions,
});
