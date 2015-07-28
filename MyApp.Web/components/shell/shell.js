(function () {
    'use strict';

    angular.module('app.shell', [])
        .controller('ShellController', [ShellController]);

    function ShellController($router) {
        var shell = this;
    }

    function ShellService() {
        var shell = {
            title: ''
        }

        return {
            getPageTitle: function () {
                return shell.title;
            },
            setPageTitle: function (title) {
                shell.title = title;
            }
        }
    }
})();