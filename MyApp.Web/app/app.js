var app = angular.module('app', [
    'ui.router',
    'app.shell',
    'app.services',
    'app.home',
    'app.user'
]);

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
            .state('users', {
                url: '/user/list',
                templateUrl: 'components/user/list.html',
                controllerAs: 'vm',
                controller: 'User.ListController'
            })
            .state('user', {
                url: '/user/:userId',
                templateUrl: 'components/user/user.html',
                controllerAs: 'vm',
                controller: 'User.UserController'
            })
        ;
    }
])