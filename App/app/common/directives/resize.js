(function () {
    'use strict';

    angular.module('app').directive('resize', function ($window) {
        return function (scope) {

            var w = angular.element($window);

            scope.getWindowDimensions = function () {
                return {
                    height: w.height(),
                    width: w.width()
                };
            };

            scope.$watch(scope.getWindowDimensions, function (newValue, oldValue) {
                scope.$broadcast('resize::resize', newValue);
            }, true);

            w.bind('resize', function () {
                scope.$apply();
            });
        }
    });

})();