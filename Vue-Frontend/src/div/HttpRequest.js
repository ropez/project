import Vue from 'vue';
import { appConfig } from './Config'

/*
    Collecting things that might change (endpoints) in one place.
*/

export const httpRequest = {

    fetchSearch(key, pageNum, pageSize) {
        if(pageSize == null)
            pageSize = appConfig.pageSize
        
        if(pageNum == null)
            pageNum = 1

         return Vue.http.get(`search?key=${key}&pageNum=${pageNum}&pageSize=${pageSize}`)
                    
    },
    fetchActor(id) {
        return Vue.http.get(`actors/${id}`)
                    
    },
    fetchMovie(id) {
        return Vue.http.get(`movies/${id}`)
    },
    fetchActorCredits(id) {
          return Vue.http.get(`actors/${id}/credits`)
    },
    fetchMovieCredits(id) {
        return Vue.http.get(`movies/${id}/credits`)
             
   },
   fetchPopular(pageNum, pageSize) {

        if(pageSize == null)
            pageSize = appConfig.numFrontPageMovies

        return Vue.http.get(`movies/popular?pageNum=${pageNum}&pageSize=${pageSize}`)          
    },
  

}
