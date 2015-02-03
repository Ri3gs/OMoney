(function () {
    'use strict';

    angular.module("oMoney").controller('restorePasswordController', ['$scope', '$location', 'authService', 'notificationService', function ($scope, $location, authService, notificationService) {
        $scope.restorePasswordViewModel = {
            email: ""
        };

        $scope.send = function () {
            authService.sendRestoreEmail($scope.restorePasswordViewModel).then(function (response) {
                $location.path("/restoreemailsent");
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function () {
            $location.path("/home");
        };

    }]);
}());