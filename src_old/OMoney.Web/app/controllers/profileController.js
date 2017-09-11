(function () {
    'use strict';
    angular.module('oMoney').controller('profileController', ['$scope', '$location', 'userService', 'notificationService', function ($scope, $location, userService, notificationService) {
        

        $scope.givegold = function() {
            userService.giveGold().then(function (response) {
                notificationService.success("Gold given!");
            }, function (response) {
                notificationService.exception(response.data);
            });
        }

        $scope.removegold = function() {
            userService.removeGold().then(function (response) {
                notificationService.success("Gold removed!");
            }, function (response) {
                notificationService.exception(response.data);
            });
        }
    }]);
}());