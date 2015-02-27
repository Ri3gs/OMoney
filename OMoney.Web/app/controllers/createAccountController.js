(function () {
    'use strict';
    angular.module('oMoney').controller('createAccountController', ['$scope', '$location', 'accountsService', 'notificationService', function ($scope, $location, accountsService, notificationService) {
        $scope.createAccountViewModel = {};
        $scope.wasCreated = false;

        $scope.create = function() {
            accountsService.createAccount($scope.createAccountViewModel).then(function(response) {
                $scope.wasCreated = true;
            }, function(response) {
                notificationService.exception(response.data);
            });
        }

    }]);
}());