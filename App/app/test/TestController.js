(function() {
    'use strict';

    var controllerName = 'TestController';

    angular.module('app').controller(controllerName, ['AppService', controller]);

    function controller(app) {
        var vm = this;

        init();

        vm.toast = {
            success: function () {
                app.toastService.toast.success({ message: 'Successful' });
            },
            info: function () {
                app.toastService.toast.info({ message: 'Info' });
            },
            error: function () {
                app.toastService.toast.error({ message: 'Error' });
            },
            warning: function () {
                app.toastService.toast.warning({ message: 'Warning' });
            },
            'long': function () {
                app.toastService.toast.error({ message: 'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industrys standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.' });
            },
        };

        function init() {
            app.shell.setPageTitle('Test');
        }

    };
})();