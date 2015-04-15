(function () {
    "use strict";
    angular.module('oMoney').controller('createAccountModalController', ['$scope', '$location', '$route', '$modalInstance', 'accountsService', 'notificationService', function ($scope, $location, $route, $modalInstance, accountsService, notificationService) {

        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };


        $scope.createAccountViewModel = {};

        $scope.create = function () {
            accountsService.createAccount($scope.createAccountViewModel).then(function () {
                $modalInstance.close();
                $route.reload();
            }, function (response) {
                notificationService.exception(response.data);
            });
        }

    }]);
}());