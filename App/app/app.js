var app = angular.module('myApp', [
    'ngNewRouter',
    'app.shell',
    'app.services',
    'app.home',
    'app.user'
]);

app.controller('AppController', ['$router', AppController]);

function AppController($router) {
    $router.config([
        { path: '/', component: 'home' },
        { path: '/user', component: 'user' },
    ]);
}
