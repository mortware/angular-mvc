(function () {
    'use strict';

    angular.module('app').directive('actionLink', function () {
        return {
            restrict: 'E',
            replace: true,
            scope: {
                label: '@',
                icon: '@',
                permissions: '@',
                href: '@',
                target: '@',
                action: '&?',
                title: '@'
            },
            templateUrl: '/common/directives/actionLink.tpl.html',
        };
    });

})();
