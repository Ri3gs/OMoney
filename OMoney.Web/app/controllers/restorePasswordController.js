(function () {
    'use strict';

    angular.module("oMoney").controller('restorePasswordController', ['$scope', '$location', 'userService', 'notificationService', 'emailNotificationService', function ($scope, $location, userService, notificationService, emailNotificationService) {
        $scope.emailSent = false;
        $scope.emailConfirmSent = false;

        $scope.restorePasswordViewModel = {
            email: ""
        };

        $scope.send = function () {
            userService.checkEmail($scope.restorePasswordViewModel.email).then(function() {
                emailNotificationService.sendRestoreEmail($scope.restorePasswordViewModel).then(function (response) {
                    $scope.emailSent = true;
                }, function (response) {
                    notificationService.exception(response.data);
                });
            }, function() {
                emailNotificationService.confirmEmailExisting($scope.restorePasswordViewModel).then(function (response) {
                    $scope.emailConfirmSent = true;
                }, function (response) {
                    notificationService.exception(response.data);
                });
            });
        };

        $scope.cancel = function () {
            $location.path("/home");
        };

    }]);
}());