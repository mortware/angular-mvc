(function () {
    'use strict';

    var controllerName = 'DrawerController';

    angular.module('app').controller(controllerName, ['$timeout', '$scope', controller]);

    function controller($timeout, $scope) {
        var vm = this,
            errors = [];

        vm.progress = [];
        vm.toasts = [];
        vm.errorStack = {
            message: '',
            count: 0
        };

        init();

        vm.removeToast = function (id) {
            vm.toasts = _.reject(vm.toasts, function (t) {
                return t.id === id;
            });
        },
        vm.removeProgress = function (id) {
            vm.progress = _.reject(vm.progress, function (t) {
                return t.id === id;
            });
        }
        vm.removeError = function (id) {
            vm.errors = _.reject(vm.errors, function (t) {
                return t.id === id;
            });
        }
        vm.dismissAllErrors = function () {
            vm.errorStack.count = errors.length = 0;
        }
        vm.expandErrors = function () {
            vm.errorStack.count = 0;
            for (var i = 0; i < errors.length; i++) {
                var error = errors[i];
                if (!_.any(vm.toasts, function (t) { return t.id === error.id; })) {
                    vm.toasts.push(error);
                }
            }
        }

        vm.firstError = function () {
            return vm.errors[Object.keys(vm.errors)[0]];
        }
        vm.errorCount = function () {
            return Object.keys(vm.errors).length;
        }

        /* Notifications */
        $scope.$on('show-toast', function (event, args) {
            var toast = args;
            if (toast.type !== 'error') {
                $timeout(function () {
                    vm.removeToast(toast.id);
                }, toast.timeout);
                toast.message += ' ' + new Date();
                vm.toasts.push(toast);
            } else {
                errors.push(toast);
                if (errors.length === 1) {
                    vm.errorStack.message = toast.message;
                    vm.errorStack.count = 1;
                } else {
                    vm.errorStack.count++;
                }
            }
        });

        $scope.$on('show-progress', function (event, args) {
            var progress = args;
            progress.busy = true;
            vm.progress.push(progress);
        });

        $scope.$on('update-progress', function (event, args) {

            if (!args) return;

            var id = args.id;
            var options = args;

            var p = _.find(vm.progress, function (i) {
                return i.id === id;
            });
            if (!p) return;

            p = _.extend(p, options);

            if (p.message) {
                p.message = $sce.trustAsHtml(p.message);
            }
            if (p.complete && p.progress) p.progress = 1.0;

            // Allow close or autoclose if finished
            if (p.complete || p.error) {
                p.busy = false;

                if (p.error) {
                    p.type = 'danger';
                }

                if (p.error || !p.autoclose) {
                    p.dismissable = true;
                } else {
                    $timeout(function () {
                        vm.removeProgress(id);
                    }, p.timeout);
                }
            }
        });

        function init() {

        }
    };
})();

