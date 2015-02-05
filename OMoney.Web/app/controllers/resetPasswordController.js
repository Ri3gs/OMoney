(function () {
    'use strict';

    angular.module("oMoney").controller('resetPasswordController', ['$scope', '$location', "$routeParams", 'authService', 'notificationService', function ($scope, $location, $routeParams, authService, notificationService) {
        $scope.passwordChanged = false;

        $scope.resetPasswordViewModel = {
            userId: $routeParams.userId,
            code: $routeParams.code,
            newPassword: "",
            confirmNewPassword: ""
        };

        $scope.reset = function () {
            authService.resetPassword($scope.resetPasswordViewModel).then(function (response) {
                $scope.passwordChanged = true;
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function () {
            $location.path("/home");
        };
    }]);
}());