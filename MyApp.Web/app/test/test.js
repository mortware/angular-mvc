(function () {
    'use strict';

    angular.module('app').config(function ($stateProvider) {

        $stateProvider
            .state('test', {
                url: '/test',
                templateUrl: 'test/test.html',
                controller: 'TestController',
                controllerAs: 'vm'
            });
    });

})();