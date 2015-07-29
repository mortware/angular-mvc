(function () {
    'use strict';

    angular.module('app.customer', [])
        .controller('Customer.EditController', [
            '$scope', '$stateParams', 'ApiService',
            function ($scope, $stateParams, api) {
                var vm = this,
                    customerId = $stateParams.customerId;

                vm.customer = null;
                vm.message = null;

                vm.save = save;

                getData();

                function getData() {
                    return api.get({
                        url: api.getUrl('Customer', 'GetCustomer'),
                        params: {
                            customerId: customerId
                        }
                    }).then(function (result) {
                        vm.customer = result.data;
                    });
                }

                function save() {
                    var request = {
                        customerId: customerId,
                        displayName: vm.customer.displayName
                    }

                    return api.post(api.getUrl('Customer', 'UpdateCustomer'), request)
                        .then(function (result) {
                            if (result.succeeded) {
                                vm.message = 'Saved OK';
                            } else {
                                vm.message = result.errors[0];
                            }
                        });
                }
            }])

        .controller('Customer.ListController', ['$scope', 'ApiService',
            function ($scope, api) {
                var vm = this;
                vm.customers = [];

                $scope.$watch('vm.filter', function (n, o) {
                    if (n === o) return;
                    getData();
                });

                getData();

                function getData() {
                    return api.get({
                        url: api.getUrl('Customer', 'List'),
                        params: {
                            filter: vm.filter
                        }
                    }).then(function (result) {
                        vm.customers = result.data;
                    });
                }
            }])

    ;

})();