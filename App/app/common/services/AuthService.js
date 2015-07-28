(function () {
    'use strict';

    /*
     * Provides user profile details and methods for checking permissions
     */

    var serviceId = 'AuthService';

    angular.module('app').service(serviceId, ['$q', 'ApiService', service]);

    function service($q, api) {

        var self = this;

        this.hasPermissions = hasPermissions;

        var profile = { permissions: [] };

        function hasPermissions(requiredPermissions) {
            if (!requiredPermissions || !requiredPermissions.length) {
                return true;
            }

            // Ensure 'requiredPermissions' is an array
            requiredPermissions = [].concat(requiredPermissions);

            return _.all(requiredPermissions, function (required) {
                return _.contains(profile.permissions, required);
            });
        }

        //function userProfile() {
        //    if (userProfilePromise != null) {
        //        return userProfilePromise;
        //    }

        //    userProfilePromise = fetchUserProfile();
        //    return userProfilePromise;
        //}

        //function fetchUserProfile() {
        //    /// <summary>
        //    /// Fetches the current user's details and permissions
        //    /// </summary>
        //    return api.get(api.getUrl('User', 'GetProfile'))
        //            .then(function (result) {
        //                profile = result;
        //                self.profile = profile;
        //                return result;
        //            })
        //        .catch(errors.catch(serviceId, "Unable to get user profile"));
        //}
    }
})();