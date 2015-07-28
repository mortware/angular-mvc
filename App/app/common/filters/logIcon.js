(function () {
    'use strict';

    // Icon filter for Log Entries
    angular.module('app').filter('logIcon', function () {
        return function (logType) {
            switch (logType) {
                case 'info':
                    return 'fa-info text-primary';
                case 'error':
                    return 'fa-times text-danger';
                case 'warning':
                    return 'fa-warning text-warning';
                case 'success':
                    return 'fa-check text-success';
                default:
                    return '';
            }
        };
    });

})();