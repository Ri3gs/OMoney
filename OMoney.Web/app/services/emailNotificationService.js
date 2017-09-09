(function () {
    'use strict';

    angular.module('oMoney').factory('emailNotificationService', ['$http', function ($http) {
        var serviceBaseUrl = 'http://localhost:4586/api/notification/';
        var emailNotificationService = {};

        var confirmEmailExisting = function (restorePasswordViewModel) {
            return $http.post(serviceBaseUrl + 'emailconfirmationexisting', restorePasswordViewModel).then(function (response) {
                return response;
            });
        }

        var sendRestoreEmail = function (restorePasswordViewModel) {
            return $http.post(serviceBaseUrl + 'restorepassword', restorePasswordViewModel).then(function (response) {
                return response;
            });
        }

        emailNotificationService.sendRestoreEmail = sendRestoreEmail;
        emailNotificationService.confirmEmailExisting = confirmEmailExisting;

        return emailNotificationService;
    }]);
}());