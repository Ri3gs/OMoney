(function () {
    'use strict';
    angular.module('oMoney').controller('profileController', ['$scope', '$location', 'authService', 'notificationService', function ($scope, $location, authService, notificationService) {
        

        $scope.givegold = function() {
            authService.giveGold().then(function (response) {
                notificationService.success("Gold given!");
            }, function (response) {
                notificationService.exception(response.data);
            });
        }

        $scope.removegold = function() {
            authService.removeGold().then(function (response) {
                notificationService.success("Gold removed!");
            }, function (response) {
                notificationService.exception(response.data);
            });
        }
    }]);
}());