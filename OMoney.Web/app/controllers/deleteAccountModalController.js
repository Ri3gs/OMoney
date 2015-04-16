(function () {
    "use strict";
    angular.module('oMoney').controller('deleteAccountModalController', ['$scope', '$location', '$route', '$modalInstance', 'accountsService', 'notificationService', 'id', function ($scope, $location, $route, $modalInstance, accountsService, notificationService, id) {

        $scope.id = id;
        $scope.deleteAccountViewModel = {};

        $scope.ok = function () {
            $scope.deleteAccountViewModel.id = id;
            accountsService.deleteAccount($scope.deleteAccountViewModel).then(function (response) {
                $modalInstance.close();
                $route.reload();
            }, function (response) {
                notificationService.exception(response.data);
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

    }]);
}());