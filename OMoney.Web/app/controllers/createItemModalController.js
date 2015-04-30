(function () {
    "use strict";
    angular.module('oMoney').controller('createItemModalController', ['$scope', '$modalInstance', 'authService', function ($scope, $modalInstance, authService) {

        $scope.newItem = {
            Buyed: false
        };

        $scope.create = function () {
            $modalInstance.close($scope.newItem);
        }

    }]);
}());