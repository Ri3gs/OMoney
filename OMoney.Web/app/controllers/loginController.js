(function () {
    "use strict";
    angular.module('oMoney').controller('loginController', ['$scope', '$state', 'authService', function($scope, $state, authService) {
        $scope.loginViewModel = {
            email: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function() {
            authService.login($scope.loginViewModel).then(function(response) {
                $state.go('profile');
            }, function(error) {
                $scope.message = error.error_description;
            });
        }
    }]);
}());