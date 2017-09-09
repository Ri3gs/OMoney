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
            var data = "client_id=ngAuthApp&grant_type=password&UserName=" + encodeURIComponent(loginViewModel.email) + "&Password=" + encodeURIComponent(loginViewModel.password);

            var deferred = $q.defer();
            $http.post(serviceBaseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                
                localStorageService.set('authenticationData', {
                    access_token: response.access_token,
                    refresh_token: response.refresh_token,
                    email: loginViewModel.email
                });

                console.log("Got new token!");

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

        var refreshToken = function () {

            var deferred = $q.defer();
            var authData = localStorageService.get('authenticationData');

            if (authData && authData.refresh_token && authData.access_token && authData.email) {

                var data = "grant_type=refresh_token&refresh_token=" + authData.refresh_token + "&client_id=ngAuthApp";

                localStorageService.remove('authenticationData');

                $http.post(serviceBaseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {

                    localStorageService.set('authenticationData', {
                        access_token: response.access_token,
                        email: response.userName,
                        refresh_token: response.refresh_token
                    });
                    console.log("Got new token! (R)");
                    deferred.resolve(response);
                }).error(function (err, status) {
                    logOut();
                    deferred.reject(err);
                });
            } else {
                deferred.reject();
            }

            return deferred.promise;
        };

        authServiceFactory.refreshToken = refreshToken;
        authServiceFactory.authentication = authentication;
        authServiceFactory.login = login;
        authServiceFactory.logOut = logOut;
        authServiceFactory.authenticate = authenticate;

        return authServiceFactory;
    }]);
}());