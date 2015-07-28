angular.module('app.user', [])
    .controller('UserController', ['ApiService', UserController]);

function UserController(api) {
    var vm = this;
    vm.username = 'Joseph Bloggingsworth';

    api.get({
        url: api.getUrl('Values', 'Get')
    }).then(function(result) {
        vm.values = result;
    });
}