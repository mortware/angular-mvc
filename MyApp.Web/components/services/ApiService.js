'use strict';

angular.module('app').factory('ApiService', ['$http', '$q', '$timeout', ApiService]);

function ApiService($http, $q, $timeout) {

    var debugPause = 10; // Note: For debugging purposes only

    return {
        get: get,
        post: post,
        getUrl: getUrl
    }

    function getUrl(controller, action) {
        return '/api/' + controller.toLowerCase() + '/' + action + '/';
    }

    function get(params, cache) {
        /// <summary>
        /// Executes a GET request to a REST API
        /// </summary>
        /// <param name="params">URL or a params object i.e. { url: 'http://api/GetUser', method: 'GET', params: { id: '87' } } </param>
        /// <returns type=""></returns>
        if (!params) { throw Error('URL is not defined'); }

        if (typeof params === 'string' || params instanceof String) {
            params = { url: params };
        }

        //params.url = params.url + 'error';

        // default config
        var config = { method: 'GET', url: '', params: {}, cache: cache || false };

        // assign params to config
        _.extend(config, params);

        var deferred = $q.defer();

        // make the api call
        $http(config).then(onSuccess, onError);

        // on success
        function onSuccess(result) {
            $timeout(function () {
                deferred.resolve(result.data);
            }, debugPause);
        }

        // on error
        function onError(error) {
            deferred.reject(error.data.message);
        }

        return deferred.promise;
    }

    function post(url, data, asParams) {
        /// <summary>
        /// Executes a POST request to a REST API
        /// </summary>
        /// <param name="params">URL or a params object i.e. { url: 'http://api/AddUser', method: 'POST', data: { id: '87', name: 'Joe Bloggs } } </param>
        /// <returns type=""></returns>
        if (!url) { throw Error('URL is not defined'); }

        var config = { method: 'POST', url: url };
        if (asParams) {
            config.params = data;
        } else {
            config.data = data;
        }

        //var config = { method: 'POST', url: url, data: data };

        var deferred = $q.defer();

        // make the api call
        $http(config).then(onSuccess, onError);

        // on success
        function onSuccess(result) {
            $timeout(function () {
                deferred.resolve(result.data);
            }, debugPause);
        }

        // on error
        function onError(error) {
            deferred.reject(error.data.message);
        }

        return deferred.promise;
    }
};