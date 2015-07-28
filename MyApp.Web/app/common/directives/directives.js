(function() {
    'use strict';

    var app = angular.module('app').config(function () { });

    app.directive('includeReplace', function () {
        return {
            require: 'ngInclude',
            restrict: 'A', /* optional */
            link: function (scope, el, attrs) {
                el.replaceWith(el.children());
            }
        };
    });

})();