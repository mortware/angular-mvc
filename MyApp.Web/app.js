var app = angular.module('app', [
    'ui.router',
    'app.shell',
    'app.services',
    'app.home',
    'app.customer'
]);

app.run(['$state', function($state) {}]);

// Declare states, urls and Controllers for the different "pages"
app.config(['$stateProvider', '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: 'components/home/home.html',
                controllerAs: 'vm',
                controller: 'HomeController'
            })
            .state('customers', {
                url: '/customers',
                templateUrl: 'components/customer/list.html',
                controllerAs: 'vm',
                controller: 'Customer.ListController'
            })
            .state('customer', {
                url: '/customer/:customerId',
                templateUrl: 'components/customer/edit.html',
                controllerAs: 'vm',
                controller: 'Customer.EditController'
            })
        ;
    }
])