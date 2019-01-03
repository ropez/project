export const mutations = {
    'SET_SEARCH_RESULT'(state, {response, key}) {
        state.numMatches = response.body.Count
        state.searchResult = response.body.Page;
        state.searchKey = key
    },
    'SET_SEARCHKEY'(state, {key}) {
        state.searchKey = key
    },
    'SET_ACTOR'(state, {response: response}) {
        state.actor = response.body
    },
    'SET_MOVIE'(state, {response: response}) {
        state.movie = response.body
    },
    'SET_ACTOR_CREDITS'(state, {response}) {
        state.actorCredits = response.body
    },
    'SET_MOVIE_CREDITS'(state, {response}) {
        state.movieCredits = response.body
    },
    'SET_ID'(state, {id, type}) {
        if(type === 'actor') {
            state.actorId = id
        } else if (type === 'movie') {
            state.movieId = id
        }
    }
    
}
