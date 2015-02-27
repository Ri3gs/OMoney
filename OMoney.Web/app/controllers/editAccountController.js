(function () {
    'use strict';
    angular.module('oMoney').controller('editAccountController', ['$scope', '$location', '$routeParams', 'accountsService', 'notificationService', 'authService', 'account', function ($scope, $location, $routeParams, accountsService, notificationService, authService, account) {
        $scope.editAccountViewModel = {
            Name: account.name,
            Amount : account.amount
        };

        $scope.update = function() {
            $scope.editAccountViewModel.id = account.id;
            $scope.editAccountViewModel.email = authService.authentication.userName;
            accountsService.updateAccount($scope.editAccountViewModel).then(function (response) {
                $location.path("/accounts");
            }, function (response) {
                notificationService.exception(response.data);
            });
        }
    }]);
}());