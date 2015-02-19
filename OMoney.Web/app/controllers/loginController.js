(function () {
    "use strict";
    angular.module('oMoney').controller('loginController', ['$scope', '$location', 'authService', 'notificationService', function ($scope, $location, authService, notificationService) {
        $scope.loginViewModel = {
            email: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            authService.login($scope.loginViewModel).then(function (response) {
                $location.path('/home');
            }, function (response) {
                notificationService.exception({ modelState: { validationErrors: [response.error_description] } });
            });
        }
    }]);
}());