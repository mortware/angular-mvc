/*
 * This service has been designed to be as generic as possible. As such, please only make changes that can be 
 * used across multiple projects. DP 2014-09-12
 */
(function () {
    'use strict';

    var serviceId = 'DialogService';

    angular.module('app').factory(serviceId, ['$mdDialog', '$timeout', service]);


    function service($mdDialog, $timeout) {

        var templatesUrl = '/common/templates/';

        return {
            alert: alert,
            prompt: prompt,
            confirm: confirm,
            open: open,

            hide: function (args) {
                $mdDialog.hide(args);
            },
            cancel: function (args) {
                $mdDialog.cancel(args);
            }
        }

        function alert(options) {

            options.title = options.title || null;
            options.content = options.content || 'No content';
            options.close = options.close || 'Close';

            var alertObj = $mdDialog.alert()
                .title(options.title)
                .content(options.content)
                .ok(options.close);

            $mdDialog.show(alertObj);

            ///// <summary>
            ///// Displays an alert dialog with a specified message and an OK button.
            ///// </summary>
            ///// <param name="message">The message to be displayed</param>
            ///// <param name="options"></param>
            ///// <returns type=""></returns>

            //options = getDefaults(options);

            //options.templateUrl = templatesUrl + 'alert.html';
            //options.controller = ['$scope', '$modalInstance', 'modalParams', function ($scope, $modalInstance, p) {

            //    $scope.message = p.message;

            //    if (p.options) {
            //        $scope.title = p.options.title;
            //        $scope.iconCss = p.options.iconCss;
            //        $scope.icon = p.options.icon;
            //        $scope.isMessageHtml = p.options.isMessageHtml;
            //    }

            //    $scope.ok = function () {
            //        $modalInstance.close(true);
            //    };

            //    $scope.cancel = function () {
            //        $modalInstance.dismiss();
            //    }
            //}
            //];
            //options.resolve = {
            //    modalParams: function () {
            //        return { message: message, options: options };
            //    }
            //}
            //return $mdDialog.show(options).result;
        }

        function open(request) {
            var options = {
                templateUrl: request.templateUrl || null,
                template: request.template || null,
                parent: request.parent || angular.element(document.body),
                clickOutsideToClose: request.clickOutsideToClose || false,
                escapeToClose: request.escapeToClose || false,
                controller: request.controller || null,
                controllerAs: request.controllerAs || 'vm',
                locals: { data: request.data }
            }
            $mdDialog.show(options);
        }
    };

})();