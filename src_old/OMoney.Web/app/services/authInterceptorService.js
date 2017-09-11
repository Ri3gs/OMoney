(function () {
    'use strict';

    angular.module('oMoney').factory('authInterceptorService', ['$q', '$location', '$injector', 'localStorageService', function ($q, $location, $injector, localStorageService) {
        var authInterceptorServiceFactory = {};
        var $http;

        var request = function (config) {

            config.headers = config.headers || {};

            var authData = localStorageService.get('authenticationData');

            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.access_token;
                config.headers.userName = authData.email;
            }

            return config;
        }

        var responseError = function (rejection) {
            var deferred = $q.defer();
            if (rejection.status === 401) {
                var authService = $injector.get('authService');
                authService.refreshToken().then(function (response) {
                    console.log("Retrying the request");
                    _retryHttpRequest(rejection.config, deferred);
                    console.log("Retried");
                }, function () {
                    console.log("Loggin out");
                    authService.logOut();
                    $location.path('/login');
                    deferred.reject(rejection);
                });
            } else {
                deferred.reject(rejection);
            }
            return deferred.promise;
        }

        var _retryHttpRequest = function (config, deferred) {
            $http = $http || $injector.get('$http');
            $http(config).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });
        }

        authInterceptorServiceFactory.request = request;
        authInterceptorServiceFactory.responseError = responseError;

        return authInterceptorServiceFactory;
    }]);
}());