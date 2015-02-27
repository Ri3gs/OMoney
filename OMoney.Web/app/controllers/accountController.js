(function () {
    'use strict';
    angular.module('oMoney').controller('accountController', ['$scope', '$location', 'accounts', 'accountsService', 'notificationService', function ($scope, $location, accounts, accountsService, notificationService) {
        $scope.accounts = accounts;
        $scope.deleteAccountViewModel = {};

        $scope.delete = function (id) {
            $scope.deleteAccountViewModel.id = id;
            accountsService.deleteAccount($scope.deleteAccountViewModel).then(function (response) {
                $location.path("/accounts");
            }, function (response) {
                notificationService.exception(response.data);
            });
        }
    }]);
}());