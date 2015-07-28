(function () {
    'use strict';

    var serviceId = 'ToastService';

    angular.module('app').factory(serviceId, ['$rootScope', service]);

    function service($rootScope) {

        return {
            toast: toast(),
            progress: progress(),
            action: action(),
        };

        function action() {
            return {
                add: add,
            }

            function add(options) {
                $rootScope.$broadcast('add-action-item', options);
            }
        }
        
        function toast() {

            return {
                info: info,
                success: success,
                error: error,
                warning: warning
            }

            function info(options) {
                return show('info', options);
            }
            function success(options) {
                return show('success', options);
            }
            function error(options) {
                return show('error', options);
            }
            function warning(options) {
                return show('warning', options);
            }

            function show(type, options) {

                // toast
                var t = {
                    id: createGuid(),
                    message: '',
                    created: new Date(),
                    autoclose: true,
                    timeout: 2000,
                    dismissable: true
                }

                if (typeof options === 'string') // Convert to object
                    t.message = options;
                else
                    t = _.extend(t, options);

                t.type = type;
                $rootScope.$broadcast('show-toast', t);
                return t.id;
            }
        }
        function progress() {

            return {
                show: show,
                update: update,
            }

            function show(options) {
                var p = {
                    id: createGuid(),
                    message: '',
                    created: new Date(),
                    autoclose: false,
                    timeout: 2000,
                    dismissable: false
                }

                if (typeof options === 'string') // Convert to object
                    p.message = options;
                else
                    p = _.extend(p, options);

                $rootScope.$broadcast('show-progress', p);
                return p.id;
            }

            function update(id, options) {

                var p = {
                    id: id,
                    updated: new Date(),
                }
                p = _.extend(p, options);

                $rootScope.$broadcast('update-progress', p);
            }
        }

        function createGuid() {
            function s4() {
                return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
            }
            return (s4() + s4() + "-" + s4() + "-4" + s4().substr(0, 3) + "-" + s4() + "-" + s4() + s4() + s4()).toLowerCase();
        }
    }
})();