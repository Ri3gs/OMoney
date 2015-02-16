(function () {
    'use strict';

    angular.module("oMoney").controller('emailConfirmationController', ['$scope', '$location', "$routeParams", 'authService', 'notificationService', function ($scope, $location, $routeParams, authService, notificationService) {
        $scope.emailConfirmed = false;
        $scope.password = false;
        $scope.passwordRecovery = $routeParams.passwordrecovery;

        $scope.emailConfirmationViewModel = {
            userId: $routeParams.userId,
            code: $routeParams.code
        };

        $scope.continue = function () {
            authService.confirmEmail($scope.emailConfirmationViewModel).then(function (response) {
                if ($scope.passwordRecovery) {
                    $scope.password = true;
                } else {
                    $scope.emailConfirmed = true;
                }
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function () {
            $location.path("/home");
        };
    }]);
}());