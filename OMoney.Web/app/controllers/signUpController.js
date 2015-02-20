(function () {
    'use strict';

    angular.module("oMoney").controller('signupController', ['$scope', '$location', 'userService', 'notificationService', function ($scope, $location, userService, notificationService) {

        $scope.signupViewModel = {
            email: "",
            password: "",
            confirmPassword: ""
        };

        $scope.signup = function() {
            userService.signup($scope.signupViewModel).then(function(response) {
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