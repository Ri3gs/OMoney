(function() {
    'use strict';

    angular.module('oMoney').factory('authService', ['$http', '$q', function($http, $q) {
        var serviceBaseUrl = 'http://localhost:4586/';
        var authServiceFactory = {};

        var authentication = {
            isAuthenticated: false,
            userName: ""
        };

        var registration = function (registrationViewModel) {
            logOut();

            return $http.post(serviceBaseUrl + 'api/user/registration', registrationViewModel).then(function(response) {
                return response;
            });
        }

        var login = function (loginViewModel) {
            var data = "grant_type=password&email=" + loginViewModel.email + "&password=" + loginViewModel.password;

            var deferred = $q.defer();

            $http.post(serviceBaseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function(response) {
                authentication.isAuthenticated = true;
                authentication.userName = loginViewModel.email;

                deferred.resolve(response);
            }).error(function(error, status) {
                logOut();
                deferred.reject(error);
            });

            return deferred.promise;
        }

        var logOut = function () {
            authentication.isAuthenticated = false;
            authentication.userName = "";
        }

        var authenticate = function () {
            authentication.isAuthenticated = true;
            authentication.userName = "test@email.com";
        }

        authServiceFactory.authentication = authentication;
        authServiceFactory.registration = registration;
        authServiceFactory.login = login;
        authServiceFactory.logOut = logOut;
        authServiceFactory.authenticate = authenticate;

        return authServiceFactory;
    }]);
}());