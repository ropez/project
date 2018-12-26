<template>
    <div>
        <page-header></page-header>
        <router-view></router-view>
        <page-footer></page-footer>

       <!-- // Når bruker søker, drop down bar som viser for hvert keypress.
        // ul med li med border for hvert element?
        // VIs navn og husk Id.
        //
        // Hvordan huske på dataene til alle objektene?
        // å de disposes? Huske at de lagres på server i 60 sek-->

    </div>
</template>
<script>
    import PageHeader from "../components/Header";
    import PageFooter from "../components/Footer";
    import Grid from "../components/Grid"
    import { eventBus } from "../main";

    export default {
        data() {
            return {

            }
        },
        components: {
            PageHeader,
            PageFooter
        },
        created() {
            this.$router.push({name:'start', text:'Hello'});
        }
    };
</script>
<style>
</style>