import Vue from 'vue';
import { appSettings } from '../Settings'
import { store } from './store';

export const actions = {
    
    setSearchKey({commit}, {key}) {

        commit('SET_SEARCHKEY', {key: key})
    },
    search({commit}, {key, pageNum, pageSize}) {

        if(pageSize == null) {
            pageSize = appSettings.pageSize
        }

        if(key == null) {
            key = store.state.searchKey
        }

        console.log(`search?key=${key}&pageNum=${pageNum}&pageSize=${pageSize}`)
         return  Vue.http.get(`search?key=${key}&pageNum=${pageNum}&pageSize=` + pageSize)
                    .then(response => {
                            commit('SET_SEARCH_RESULT', {response: response, key: key})
                            console.log(response)
                            return response;
                    })
                 
                
    },
    setId({commit}, {id, type}) {
        commit('SET_ID', {id: id, type: type})
    },
    fetchActor({commit}) {
        const id = store.state.actorId
        return Vue.http.get(`actors/${id}`)
                    .then(response => {
                          commit('SET_ACTOR', {response: response})
                          console.log(response)
                          return response
                    })
    },
    fetchMovie({commit}) {
        const id = store.state.movieId
        return Vue.http.get(`movies/${id}`)
                   .then(response => {
                         commit('SET_MOVIE', {response: response})
                         console.log(response)
                         return response
                   })
   },
   fetchActorCredits({commit}) {
          const id = store.state.actorId
          Vue.http.get(`actors/${id}/credits`,)
                    .then(response => {
                        commit('SET_ACTOR_CREDITS', {response: response})
                    })
    },
    fetchMovieCredits({commit}) {
        const id = store.state.movieId
        Vue.http.get(`movies/${id}/credits`,)
                  .then(response => {
                      commit('SET_MOVIE_CREDITS', {response: response})
                  })
   },

}
