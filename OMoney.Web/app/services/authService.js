(function() {
    'use strict';

    angular.module('oMoney').factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
        var serviceBaseUrl = 'http://localhost:4586/';
        var authServiceFactory = {};

        var authentication = {
            isAuthenticated: false,
            userName: ""
        };

        var login = function (loginViewModel) {
            var data = "grant_type=password&UserName=" + encodeURIComponent(loginViewModel.email) + "&Password=" + encodeURIComponent(loginViewModel.password);

            var deferred = $q.defer();
            $http.post(serviceBaseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                
                localStorageService.set('authenticationData', { token: response.access_token, email: loginViewModel.email });

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
            localStorageService.remove('authenticationData');

            authentication.isAuthenticated = false;
            authentication.userName = "";
        }

        var authenticate = function () {
            var authenticationData = localStorageService.get('authenticationData');
            if (authenticationData) {
                authentication.isAuthenticated = true;
                authentication.userName = authenticationData.email;
            }
        }

        authServiceFactory.authentication = authentication;
        authServiceFactory.login = login;
        authServiceFactory.logOut = logOut;
        authServiceFactory.authenticate = authenticate;

        return authServiceFactory;
    }]);
}());