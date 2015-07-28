(function () {
    'use strict';

    angular.module('app.user', [])
        .controller('User.UserController', ['$scope', 'ApiService', controller]);

    function controller($scope, api) {
        var vm = this;

        getData();

        function getData() {
            return api.get({
                url: api.getUrl('User', 'List'),
                params: {
                    filter: vm.filter
                }
            }).then(function (result) {
                vm.users = result.data;
            });
        }
    }
})();