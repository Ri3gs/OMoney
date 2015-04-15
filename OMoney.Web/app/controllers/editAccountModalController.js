(function () {
    "use strict";
    angular.module('oMoney').controller('editAccountModalController', ['$scope', '$location', '$route', '$modalInstance', 'accountsService', 'authService', 'notificationService', 'account', function ($scope, $location, $route, $modalInstance, accountsService, authService, notificationService, account) {

        $scope.editAccountViewModel = {
            Name: account.name,
            Amount: account.amount
        };

        $scope.update = function () {
            $scope.editAccountViewModel.id = account.id;
            $scope.editAccountViewModel.email = authService.authentication.userName;
            accountsService.updateAccount($scope.editAccountViewModel).then(function (response) {
                $modalInstance.close();
                $route.reload();
            }, function (response) {
                notificationService.exception(response.data);
            });
        }

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }

    }]);
}());