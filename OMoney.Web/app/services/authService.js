(function() {
    'use strict';

    angular.module('oMoney').factory('authService', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
        var serviceBaseUrl = 'http://localhost:4586/';
        var authServiceFactory = {};

        var authentication = {
            isAuthenticated: false,
            userName: ""
        };

        var resetPassword = function (resetPasswordViewModel) {
            return $http.post(serviceBaseUrl + 'api/user/resetpassword', resetPasswordViewModel).then(function (response) {
                return response;
            });
        }

        var sendRestoreEmail = function (restorePasswordViewModel) {
            return $http.get(serviceBaseUrl + 'api/user/restorepassword', { params: restorePasswordViewModel }).then(function (response) {
                return response;
            });
        }

        var changePassword = function(changePasswordViewModel) {
            logOut();

            return $http.post(serviceBaseUrl + 'api/user/changepassword', changePasswordViewModel).then(function (response) {
                return response;
            });
        }

        var signup = function (signupViewModel) {
            logOut();

            return $http.post(serviceBaseUrl + 'api/user/signup', signupViewModel).then(function (response) {
                return response;
            });
        }

        var login = function (loginViewModel) {
            var data = "grant_type=password&UserName=" + loginViewModel.email + "&Password=" + loginViewModel.password;

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
        authServiceFactory.signup = signup;
        authServiceFactory.login = login;
        authServiceFactory.logOut = logOut;
        authServiceFactory.authenticate = authenticate;
        authServiceFactory.changePassword = changePassword;
        authServiceFactory.sendRestoreEmail = sendRestoreEmail;
        authServiceFactory.resetPassword = resetPassword;

        return authServiceFactory;
    }]);
}());