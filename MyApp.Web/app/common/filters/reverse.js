﻿(function () {
    'use strict';

    angular.module('app').filter('reverse', function () {
        return function (items) {
            if (items) {
                return items.slice().reverse();
            }
            return [];
        };
    });

})();