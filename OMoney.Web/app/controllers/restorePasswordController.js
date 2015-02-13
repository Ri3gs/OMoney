(function () {
    'use strict';

    angular.module("oMoney").controller('restorePasswordController', ['$scope', '$location', 'authService', 'notificationService', function ($scope, $location, authService, notificationService) {
        $scope.emailSent = false;
        $scope.emailConfirmSent = false;

        $scope.restorePasswordViewModel = {
            email: ""
        };

        $scope.send = function () {
            authService.checkEmail($scope.restorePasswordViewModel.email).then(function() {
                authService.sendRestoreEmail($scope.restorePasswordViewModel).then(function (response) {
                    $scope.emailSent = true;
                }, function (response) {
                    notificationService.exception(response.data);
                });
            }, function() {
                authService.confirmEmailExisting($scope.restorePasswordViewModel).then(function (response) {
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