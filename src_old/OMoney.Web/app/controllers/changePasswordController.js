(function () {
    'use strict';

    angular.module("oMoney").controller('changePasswordController', ['$scope', '$location', 'authService', 'notificationService', 'userService' , function ($scope, $location, authService, notificationService, userService) {
        $scope.passwordChanged = false;

        $scope.changePasswordViewModel = {
            email: authService.authentication.userName,
            oldPassword: "",
            newPassword: "",
            confirmNewPassword: ""
        };

        $scope.change = function () {
            userService.changePassword($scope.changePasswordViewModel).then(function (response) {
                $scope.passwordChanged = true;
                authService.logOut();
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function () {
            $location.path("/home");
        };

    }]);
}());