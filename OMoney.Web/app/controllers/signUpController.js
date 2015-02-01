(function () {
    'use strict';

    angular.module("oMoney").controller('signupController', ['$scope', '$location', 'authService', 'notificationService', function ($scope, $location, authService, notificationService) {

        $scope.signupViewModel = {
            email: "",
            password: "",
            confirmPassword: ""
        };

        $scope.signup = function() {
            authService.signup($scope.signupViewModel).then(function(response) {
                $location.path("/activation");
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function() {
            $location.path("/home");
        };
    }]);
}());