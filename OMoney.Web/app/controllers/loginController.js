(function () {
    "use strict";
    angular.module('oMoney').controller('loginController', ['$scope', '$location', 'authService', function($scope, $location, authService) {
        $scope.loginViewModel = {
            email: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            authService.login($scope.loginViewModel).then(function(response) {
                $location.path('/home');
            }, function(error) {
                $scope.message = error.error_description;
            });
        }
    }]);
}());