(function () {
    'use strict';

    angular.module('app.shell', [])

        .controller('ShellController', [function () {
            var vm = this;
        }])

        .factory('ShellService', [function () {
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
        }])
    ;

})();