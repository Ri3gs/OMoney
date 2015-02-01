(function () {
    'use strict';

    angular.module("oMoney").controller('signupController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

        $scope.signupViewModel = {
            email: "",
            password: "",
            confirmPassword: ""
        };

        $scope.signup = function() {
            authService.signup($scope.signupViewModel).then(function(response) {
                $location.path("/activation");
            }, function(response) {

            });
        };

        $scope.cancel = function() {
            $location.path("/home");
        };
    }]);
}());