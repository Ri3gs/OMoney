(function() {
    "use strict";
    angular.module('oMoney').controller('homeController', ['$scope', '$location', 'userService', 'notificationService', 'authService', function ($scope, $location, userService, notificationService, authService) {
        $scope.authentication = authService.authentication;
        $scope.signupViewModel = {
            email: "",
            password: "",
            confirmPassword: ""
        };

        $scope.signup = function () {
            userService.signup($scope.signupViewModel).then(function (response) {
                $location.path("/activation");
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function () {
            $location.path("/home");
        };
    }]);
}());