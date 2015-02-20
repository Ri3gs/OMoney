(function () {
    'use strict';

    angular.module('oMoney').factory('userService', ['$http', 'authService' , function ($http, authService) {
        var serviceBaseUrl = 'http://localhost:4586/api/user/';
        var userServiceFactory = {};

        var removeGold = function () {
            return $http.post(serviceBaseUrl + 'removegold', { email: authService.authentication.userName }).then(function (response) {
                return response;
            });
        }

        var giveGold = function () {
            return $http.post(serviceBaseUrl + 'givegold', { email: authService.authentication.userName }).then(function (response) {
                return response;
            });
        }

        var checkEmail = function (email) {
            return $http.get(serviceBaseUrl + 'checkemail', { params: { email: email } }).then(function (response) {
                return response;
            });
        }

        var confirmEmail = function (emailConfirmationViewModel) {
            return $http.post(serviceBaseUrl + 'activate', emailConfirmationViewModel).then(function (response) {
                return response;
            });
        }

        var resetPassword = function (resetPasswordViewModel) {
            return $http.post(serviceBaseUrl + 'resetpassword', resetPasswordViewModel).then(function (response) {
                return response;
            });
        }

        var changePassword = function (changePasswordViewModel) {
            return $http.post(serviceBaseUrl + 'changepassword', changePasswordViewModel).then(function (response) {
                return response;
            });
        }

        var signup = function (signupViewModel) {
            //logOut();

            return $http.post(serviceBaseUrl + 'signup', signupViewModel).then(function (response) {
                return response;
            });
        }

        userServiceFactory.signup = signup;
        userServiceFactory.changePassword = changePassword;
        userServiceFactory.resetPassword = resetPassword;
        userServiceFactory.confirmEmail = confirmEmail;
        userServiceFactory.checkEmail = checkEmail;
        userServiceFactory.giveGold = giveGold;
        userServiceFactory.removeGold = removeGold;

        return userServiceFactory;
    }]);
}());