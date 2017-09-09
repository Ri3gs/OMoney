(function () {
    "use strict";
    angular.module('oMoney').controller('editAccountModalController', ['$scope', '$location', '$route', '$modalInstance', 'accountsService', 'authService', 'notificationService', 'account', function ($scope, $location, $route, $modalInstance, accountsService, authService, notificationService, account) {

        $scope.editAccountViewModel = {
            Name: account.name,
            Amount: account.amount,
            Comments: account.comments,
            AccountType: account.accountType,
            AccountCurrency: account.accountCurrency,
            id: account.id,
            email: authService.authentication.userName
        };


        $scope.update = function () {
            $modalInstance.close($scope.editAccountViewModel);
        }

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }

    }]);
}());