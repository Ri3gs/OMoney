(function () {
    'use strict';

    angular.module("oMoney").controller('emailConfirmationController', ['$scope', '$location', "$routeParams", 'authService', 'notificationService', function ($scope, $location, $routeParams, authService, notificationService) {

        $scope.emailConfirmationViewModel = {
            userId: $routeParams.userId,
            code: $routeParams.code
        };

        $scope.continue = function () {
            authService.confirmEmail($scope.emailConfirmationViewModel).then(function (response) {
                $location.path("/emailconfirmed");
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function () {
            $location.path("/home");
        };
    }]);
}());