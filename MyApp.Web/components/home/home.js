(function () {
    'use strict';

    angular.module('app.home', [])
        .controller('HomeController', [HomeController]);


    function HomeController() {
        var home = this;

        home.welcomeMessage = 'You are home.';
    }

})();